# NSAP-1 (Not Simple as Possible)

![NSAP1](https://github.com/Diogo-Valadares/NSAP-1/assets/58271577/b2e1aaf5-f8dc-4465-84c0-f2a8eeef4a51)

## Overview
NSAP-1 is an computational architecture that builds upon the principles of the SAP-1 (Simple as Possible) computer but introduces higher complexity and functionality. This is a personal project with the intention of just learning about computers architectures.

## Features
- **Full 8-bit Memory Address**: Unlike SAP-1's limited 4-bit address space, NSAP-1 boasts a full 8-bit memory address, enabling access to 256 memory locations.
- **Extended Instruction Set**: With a full 8-bit instruction register, NSAP-1 can perform 256 different instructions, a significant leap from SAP-1's 16 instructions.
- **Efficient Instruction Cycles**: Each instruction executes in at most 8 cycles, with a minimum of 2 cycles (fetch address from Program Counter and fetch information from RAM).
- **Video Processing Unit** A rudimentary video processing unit is currently in development. It operates as a separate ALU for video registers.

## Future Enhancements
- **Video Processing**: Plans are in place to further develop the video processing capabilities.
- **Stack Implementation**: A stack will be added to enhance the computational operations and memory management.
- **Flags**: There are plans for adding flags(such as overflow, equality, etc.), which will be fundamental for conditional jump instructions.

## ALU Operations
- The ALU operations require pre-loading the information register B before executing the ALU instruction.
- The result of an operation is stored in a dedicated ALU result register, not in the accumulator (Register A).

## Getting Started
To work with NSAP-1, you will need:
- **Logisim Evolution**: An educational tool for designing and simulating digital logic circuits.
- **VHDL Simulator**: A tool like Altera ModelSim must be installed on your machine and linked to Logisim Evolution to simulate VHDL designs.

## Assembler
The project includes a C# assembler that allows you to create programs that can be loaded directly into the NSAP-1's RAM.

## Documentation
The documentation process is ongoing. We aim to provide comprehensive information to help you understand and contribute to the project effectively.
There is an Google Sheets table listing the current instructions at
https://docs.google.com/spreadsheets/d/1OhQx1rbJFWxC1zU1svIcuST1hLUuEzyAFOE7Zm_RUqI/edit#gid=501750655

## Contributing
We welcome contributions and suggestions! Feel free to fork the repository, create a feature branch, and submit your pull requests for review.


This README is a work in progress, as is the NSAP-1 project itself. Stay tuned for updates and enhancements!
