// Sharp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//


#include <iostream>
#include <string>
#include <sstream>
#include <regex>


#define OFF_PAUSE_SIZE (40000)
#define OFF_1_SIZE (1680)
#define OFF_0_SIZE (680)
#define ON_SIZE (320)

#define VALID_VALUE(VALUE,REF)  (((VALUE>=(REF/2))&&(VALUE<=(1.5*REF)))?true:false)



/*

*/

static std::string encode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";

    /* Work variables. */
    int bits_tracker = 63;

    /* Protocol variables. */
    int ext_chk = 2;
    int address = -1;
    int command = -1;
    int command2 = -1;
    uint32_t data = 0;

    if (argc == 3)
    {
        /* Obtain the values. */
        std::string str = "";
        char** end_str = NULL;
        std::string argument = "";

        while (argc--)
        {
            str = "address:";
            argument = argv[argc];
            if (argument.find(str) == 0)
            {
                str = (argv[argc] + 8);
                address = strtol(str.c_str(), end_str, 10);

                if (errno != 0)
                {
                    return reply;
                }
            }
            else
            {
                str = "command:";
                if (argument.find(str) == 0)
                {
                    str = (argv[argc] + 8);
                    command = strtol(str.c_str(), end_str, 10);

                    if (errno != 0)
                    {
                        return reply;
                    }
                }
                else
                {
                    return reply;
                }
            }
        }


        if ((address >= 0 && address <= 0x1F) && (command >= 0 && command <= 0xFF))
        {
            data = address & 0xFF;
            data <<= 5;
            data += (command & 0x1F);
            data <<= 8;
            data += ext_chk;/*Value 2.*/

            int counter = 15;
            while (counter--)
            {
                reply += std::to_string(ON_SIZE) + " ";

                if (0 != (data & (1 << counter)))
                {
                    reply += std::to_string(OFF_1_SIZE);
                }
                else
                {
                    reply += std::to_string(OFF_0_SIZE);
                }

            }

            reply += " " + std::to_string(ON_SIZE) + " " + std::to_string(OFF_PAUSE_SIZE) + " ";


            data = address & 0xFF;
            data <<= 5;
            data += (~command & 0x1F);
            data <<= 8;
            data += (~ext_chk & 0x03);/* Value 1.*/

            counter = 15;
            while (counter--)
            {

                reply += std::to_string(ON_SIZE) + " ";

                if (0 != (data & (1 << counter)))
                {
                    reply += std::to_string(OFF_1_SIZE);
                }
                else
                {
                    reply += std::to_string(OFF_0_SIZE);
                }
            }

            reply += " " + std::to_string(ON_SIZE) + "\n\r";
        }
    }

    return reply;
}


static std::string decode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";

    /* Work variables. */
    char** end_str = NULL;
    int time_off = 0;
    int time_on = 0;
    int times_tracker = 0;

    /* Protocol variables. */
    uint64_t data = 0;
    uint64_t data2 = 0;
    int address = 0;
    int command = 0;
    int address2 = 0;
    int command2 = 0;

    if (argc == 63)
    {
        

        /* Normal packet half. */
        while (times_tracker < 30)
        {
            time_on = strtol(argv[times_tracker++], end_str, 10);
            time_off = strtol(argv[times_tracker++], end_str, 10);
                    

            data *= 2;
            if (VALID_VALUE(time_on, ON_SIZE))
            {
                if (VALID_VALUE(time_off, OFF_0_SIZE))
                {
                    data += 0;
                }
                else
                    if (VALID_VALUE(time_off, OFF_1_SIZE))
                    {
                        data += 1;
                    }
                    else
                    {
                        return reply;
                    }
            }
            else
            {
                return reply;
            }

        }

        /* Interregnum. */
        time_on = strtol(argv[times_tracker++], end_str, 10);
        time_off = strtol(argv[times_tracker++], end_str, 10);

        if (VALID_VALUE(time_off, OFF_PAUSE_SIZE))
        {
            if (VALID_VALUE(time_on, ON_SIZE))
            {
            }
            else
            {
                return reply;
            }
        }
        else
        {
            return reply;
        }


        /* Inverted packet half. */
        while (times_tracker < (argc-1))
        {
            time_on = strtol(argv[times_tracker++], end_str, 10);
            time_off = strtol(argv[times_tracker++], end_str, 10);

            data2 *= 2;
            if (VALID_VALUE(time_on, ON_SIZE))
            {
                if (VALID_VALUE(time_off, OFF_0_SIZE))
                {
                    data2 += 0;
                }
                else
                    if (VALID_VALUE(time_off, OFF_1_SIZE))
                    {
                        data2 += 1;
                    }
                    else
                    {
                        return reply;
                    }
            }
            else
            {
                return reply;
            }

        }

        /* Validate closing bit. */
        time_on = strtol(argv[times_tracker++], end_str, 10);
        if (!VALID_VALUE(time_on, ON_SIZE))
        {
            return reply;
        }

        /* Data is ready, convert and validate. */
        address = 0x1F & data;/*5bits*/
        data >>= 5;
        command = 0xFF & data;/*8bits*/
        data >>= 8;
        /* Left in data is now expantion and check, corresponding to value 2. */

        address2 = 0x1F & data2;/*5bits*/
        data2 >>= 5;
        command2 = 0xFF & data2;/*8bits*/
        data2 >>= 8;
        /* Left in data is now expantion and check, corresponding to value 2. */

        if((data == (~data2&0x03))&&(address == address2)&&(command == (~command2&0xFF)))
        {
            reply = "command:" + std::to_string(command) + " address:" + std::to_string(address) + "\n\r";
        }
        else
        {
            return reply;
        }
    }

    return reply;
}


int main(int argc, char* argv[])
{
    std::string result = "";
    int return_val = 0;

    try
    {
        if (argc != 0)
        {
            if (0 == strcmp(argv[1], "encode"))
            {
                result = encode(argc - 2, &argv[2]);
            }
            else if (0 == strcmp(argv[1], "decode"))
            {
                result = decode(argc - 2, &argv[2]);
            }
            else
            {
                return_val = -1;
            }

        }
        else
        {
            return_val = -1;
        }
    }
    catch (int exception)
    {

    }


    std::cout << result + "\r\n";

    if ("" == result)
    {
        return_val = -1;
    }

    return return_val;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
