// RC5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <sstream>
#include <regex>


#define HALF_BIT_SIZE (890)
#define FULL_BIT_SIZE (2*HALF_BIT_SIZE)
#define VALID_HALF_BIT(VALUE)  (((VALUE>=(HALF_BIT_SIZE/2))&&(VALUE<=(HALF_BIT_SIZE+(HALF_BIT_SIZE/2))))?true:false)
#define VALID_FULL_BIT(VALUE)  (((VALUE>=(HALF_BIT_SIZE))&&(VALUE<=(FULL_BIT_SIZE+(HALF_BIT_SIZE))))?true:false)

/*

Test data
encode toggle:0 address:5 command:53
decode 890 890 1780 890 890 890 890 1780 1780 1780 890 890 890 890 1780 1780 1780 1780 890 

*/

static std::string encode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";

    /* Work variables. */
    int half_bit_counter = 0;
    int bits_tracker = 14;
    int bit_value = 1;
    int polarity = 1;
    int time[100] = { HALF_BIT_SIZE };

    /* Protocol variables. */
    uint16_t data = 3<<12;
    int toggle = -1;
    int address = -1;
    int command = -1;

    if (argc == 3)
    {
        /* Obtain the values. */
        std::string str = "";
        char **end_str = NULL;
        std::string argument = "";

        while (argc--)
        {
            str = "toggle:";
            argument = argv[argc];
            if (argument.find(str) == 0)
            {
                str = (argv[argc] + 7);
                toggle = strtol(str.c_str(), end_str, 10);

                if (errno != 0)
                {
                    return reply;
                }
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


        if ((toggle == 0 || toggle == 1) && (address >= 0 && address <= 0x1F) && (command >= 0 && command <= 0x3F))
        {
            /* Ready to encode. */

            data += (toggle << 11) + (address << 6) + command;
            int bit = 0;
            while (bits_tracker > 0)
            {
                bits_tracker--;
                time[half_bit_counter] = HALF_BIT_SIZE;
                time[half_bit_counter + 1] = HALF_BIT_SIZE;

                bit = (0 != (data & (1 << bits_tracker))) ? 1 : 0;

                if (bit != bit_value)
                {

                    half_bit_counter -= 1;
                    time[half_bit_counter - 1] += HALF_BIT_SIZE;

                    bit_value = bit;
                }


                half_bit_counter += 2;
            }

            half_bit_counter -= 1;
            if (bit == 0)
            {
                half_bit_counter -= 1;
            }

            bits_tracker = 0;
            while (bits_tracker < half_bit_counter)
            {
                reply += " " + std::to_string(time[bits_tracker]);

                bits_tracker++;
            }

            reply += "\n\r";
            return reply;

        }
        else
        {
            return reply;
        }
    }
}


static std::string decode(int argc, char* argv[])
{
    /* Result variables. */
    std::string reply = "";
    
    /* Work variables. */
    int half_bit_counter = 27;
    int times_tracker = 0;
    int bit_value = 1;
    int polarity = 1;
    bool full_bit = false;

    /* Protocol variables. */
    uint16_t data = 0;
    int toggle = 0;
    int address = 0;
    int command = 0;

    /* */
    if ((argc <= 27) && (argc >= 15))
    {


        while ((half_bit_counter > 0) && (argc > 0))
        {
            int time = atoi(argv[times_tracker++]);

            argc--;

            if (1 == half_bit_counter % 2)
            {
                data <<= 1;
                data += bit_value;
            }

            if (VALID_HALF_BIT(time))
            {
                half_bit_counter -= 1;
            }
            else
            if (VALID_FULL_BIT(time))
            {
                if (half_bit_counter > 1)
                {
                    bit_value = 1 - bit_value;
                    half_bit_counter -= 2;
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

            polarity = 1 - polarity;

        }

        if (half_bit_counter > 0)
        {
            data <<= 1;
        }

        toggle = (data & (1 << 11U));

        if (toggle != 0U)
        {
            toggle = 1;
        }

        address = ((data >> 6)&0x1F);

        command = (data & 0x3F);

        
        reply = "toggle:" + std::to_string(toggle) + " address:" + std::to_string(address) + " command:" + std::to_string(command) + "\n\r";
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
        return_val =  -1;
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
