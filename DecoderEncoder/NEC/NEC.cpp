// RC5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <sstream>
#include <regex>


#define HEADER_ON_SIZE (9000)
#define HEADER_OFF_SIZE (4500)

#define ON_SIZE (550)
#define OFF_0_SIZE (ON_SIZE)
#define OFF_1_SIZE (3*ON_SIZE)

#define VALID_VALUE(VALUE,REF)  (((VALUE>=(REF/2))&&(VALUE<=(1.5*REF)))?true:false)



/*

Test data
encode repeat:1
encode address:5 command:53
decode 

*/

static std::string encode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";

    /* Work variables. */
    int bits_tracker = 14;
  
    /* Protocol variables. */
    int repeat = -1;
    int address = -1;
    int command = -1;
    uint32_t data = 0;

    if (argc == 1 || argc == 2)
    {
            /* Obtain the values. */
            std::string str = "";
            char** end_str = NULL;
            std::string argument = "";

            while (argc--)
            {
                str = "repeat:1";
                argument = argv[argc];
                if (argument.find(str) == 0)
                {
                    reply = std::to_string(HEADER_ON_SIZE) + " " + std::to_string(HEADER_OFF_SIZE/2) + " " + std::to_string(ON_SIZE) + "\n\r";
                    return reply;
                }
                else
                {
                    str = "address:";
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
            }

            

            if ((address >= 0 && address <= 0xFF) && (command >= 0 && command <= 0xFF))
            {
                reply = std::to_string(HEADER_ON_SIZE) + " " + std::to_string(HEADER_OFF_SIZE) + " ";

                data = address & 0xFF;
                data <<= 8;
                data += ((~address) & 0xFF);
                data <<= 8;
                data += command & 0xFF;
                data <<= 8;
                data += ((~command) & 0xFF);

                int counter = 32;
                while (counter--)
                {
                    reply += std::to_string(ON_SIZE) + " ";

                    if (0 != (data & (1 << counter)))
                    {
                        reply += std::to_string(OFF_1_SIZE) + " ";
                    }
                    else
                    {
                        reply += std::to_string(OFF_0_SIZE) + " ";
                    }
                }

                reply += std::to_string(ON_SIZE) + "\n\r";
            }
    }

    return reply;
}


static std::string decode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";

    /* Work variables. */
    int times_tracker = 0;
    int time_val = 0;
    char** end_str = NULL;

    /* Protocol variables. */
    uint32_t data = 0;
    int address = 0;
    int command = 0;
    int n_address = 0;
    int n_command = 0;

    

    if (argc == 67)
    {
        /* Evaluate the header times. */
        time_val = strtol(argv[times_tracker++], end_str, 10);
        if (VALID_VALUE(time_val, HEADER_ON_SIZE))
        {
            time_val = strtol(argv[times_tracker++], end_str, 10);

            if (VALID_VALUE(time_val, HEADER_OFF_SIZE))
            {
                
                /* Header found. Decode the data. */
                while (times_tracker < (argc-1))
                {
                    int time_on = strtol(argv[times_tracker++], end_str, 10);
                    int time_off = strtol(argv[times_tracker++], end_str, 10);
                    data <<= 1;
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

                
                /* Decode data end. */
                time_val = strtol(argv[times_tracker++], end_str, 10);
                if (!VALID_VALUE(time_val, ON_SIZE))
                {
                    return reply;
                }

                /* Data is ready, convert and validate. */
                n_command = 0xFF & data;
                data >>= 8;
                command = 0xFF & data;
                data >>= 8;
                n_address = 0xFF & data;
                data >>= 8;
                address = 0xFF & data;

                n_command = ((~n_command) & 0xFF);
                n_address = ((~n_address) & 0xFF);
                
                if ((command == n_command) && (address == n_address))
                {

                    reply = "address:" + std::to_string(address) + " command:" + std::to_string(command) + "\n\r";
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
        else
        {
            return reply;
        }
    }
    else
    if (argc == 3)
    {
        /* Evaluate the header times. */
        time_val = strtol(argv[times_tracker++], end_str, 10);
        if (VALID_VALUE(time_val, HEADER_ON_SIZE))
        {
            time_val = strtol(argv[times_tracker++], end_str, 10);
            if (VALID_VALUE(time_val, HEADER_OFF_SIZE/2))
            {
                /* Header found. Decode the data. */
                time_val = strtol(argv[times_tracker++], end_str, 10);
                if (VALID_VALUE(time_val, ON_SIZE))
                {
                    reply += "repeat:1\n\r";
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
        else
        {
            return reply;
        }
    }
    else
    {
        return reply;
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
