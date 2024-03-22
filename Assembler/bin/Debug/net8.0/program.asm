LD_A FD		//regA = #FD -> 'a'
LD_I_B 02	//regB = 02
MUL			//ulaReg = 2'a'
ST_U FC		//#FC = 2'a'

LD_B FF		//regB = #FF -> 'c'
MUL			//ulaReg = 'a''c'
LD_U_A		//regA = 'a''c'
LD_I_B 04	//regB = 04
MUL			//ulaReg = 4'a''c'
ST_U FB		//#FB = 4ac

LD_A FE		//regA = #FE -> 'b'
LD_B FE		//regB = #FE -> 'b'
MUL			//ulaReg = 'b'^2
LD_U_A		//regA = 'b'^2
LD_B FB		//regB = #FB -> 4'a''c'
SUB			//ulaReg = 'b'^2-4'a''c'

#FD 40 23 24 //variáveis 'a' 'b' e 'c'