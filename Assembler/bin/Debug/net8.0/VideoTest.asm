CLR_DISPL	//clear display
V_SET_I RGB FF	//Color white
V_SET_I XY 00	//resets screen cursor position on x and y

LD_I_A 00	//regA = 0
LD_I_B 00	//regB = 0

:start
MUL			//ulaReg = regA * regB
V_SET_U Y	//sets screen cursor position on y from ALU
V_SET_I O 05	//sets an operand for the next operation
V_OP DIV Y	//divides screen cursor position on y by 5
DRAW		//makes screen writer draw
INC_A		//regA = regA + 1
INC_B		//regB = regB + 1
V_OP INC_A X //increments screen cursor position on x


GO_TO :start