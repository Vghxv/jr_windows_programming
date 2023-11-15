using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
				class Model
				{
				
								const char CHARACTER_0 = '0';
								const string STRING_0 = "0";
								const char PLUS_SIGN = '+';
								const char MINUS_SIGN = '-';
								const char MULTIPLY_SIGN = '*';
								const char DIVIDE_SIGN = '/';
								const char DOT = '.';
								private bool _delay = false;
								private bool _isResult = false;
								private char _operator = CHARACTER_0;
								private string _buffer = STRING_0;
								private string _memory = "";
								private string _previous = "";

								public Model()
								{
								}
								// perform operation 
								public double CalculateNumber(double number1, double number2, char operation)
								{
												switch (operation)
												{
																case PLUS_SIGN:
																				return number1 + number2;
																case MINUS_SIGN:
																				return number1 - number2;
																case MULTIPLY_SIGN:
																				return number1 * number2;
																case DIVIDE_SIGN:
																				if (number2 != 0)
																								return number1 / number2;
																				return 0;
												}
												return 0;
								}

								// number click
								public void ClickNumber(char number)
								{
												this._previous = "";
												if (number == CHARACTER_0)
												{
																if (_buffer[0] == CHARACTER_0) 
																{
																				return;
																}
																AddToBuffer(number);
												}
												else
												{
																if (_buffer.Length == 1 && _buffer[0] == CHARACTER_0)
																{
																				PopBuffer();
																}
																AddToBuffer(number);
												}
								}

								// operator click
								public void ClickOperator(char operater)
								{
												this._previous = "";
												if (this._operator != CHARACTER_0 && this._buffer.Length != 0 && this._memory.Length != 0) 
												{
																Double.TryParse(this._memory,out double num1);
																Double.TryParse(this._buffer, out double num2);
				
																this._memory = this.CalculateNumber(num1, num2, this._operator).ToString();
																this._buffer = "";
																this._isResult = true;
												}
												else if (this._operator == CHARACTER_0)
												{
																this._memory = this._buffer;
												}
												_operator = operater;
												this._delay = true;	
								}

								// equal click
								public void ClickEqual()
								{
												if (this._operator != CHARACTER_0 && this._previous.Length != 0 )
												{
																Double.TryParse(this._memory,out double num3);
																Double.TryParse(this._previous, out double num4);
																this._memory = this.CalculateNumber(num3, num4, this._operator).ToString();
																this._isResult = true;
												}
												else if (this._operator != CHARACTER_0 && this._buffer.Length != 0 )
												{
																this._previous = this._buffer;
																Double.TryParse(this._memory,out double num1);
																Double.TryParse(this._buffer, out double num2);
																this._memory = this.CalculateNumber(num1, num2, this._operator).ToString();
																this._buffer = STRING_0;
																this._isResult = true;
												}	
								}

								// click dot
								public void ClickDotButton()
								{
												if ( !CheckAnyDot() )
												{
																this._buffer = this._buffer + DOT;
												}
								}

								// clear
								public void Clear()
								{
												this._buffer = STRING_0;
												this._memory = "";
												this._operator = CHARACTER_0;
								}

								// clear entry
								public void ClearEntry()
								{
												this._buffer = STRING_0;
								}

								// claer entry by delay
								public void ClearEntryByDelay()
								{
												if (this._delay )
												{
																this._buffer = STRING_0;
												}
								}

								// append buffer
								public void AddToBuffer(char character)
								{
								
												this._buffer = this._buffer + character;
								}

								// pop buffer
								public void PopBuffer()
								{
												this._buffer = this._buffer.Remove(this._buffer.Length - 1);
								}

								// set is result
								public void SetResult(bool isResult)
								{
												this._isResult = isResult;
								}
		
								// get is result
								public bool IsResult() 
								{
												return this._isResult;  
								}

								// set delay
								public void SetDelay(bool delay)
								{
												this._delay = delay;
								}

								//get delay
								public bool IsDelay() 
								{
												return this._delay; 
								}

								// get buffer
								public string GetBuffer()
								{
												return this._buffer;
								}

								// get memory
								public string GetMemory()
								{
												return this._memory;
								}

								// get operator
								public char GetOperator()
								{
												return this._operator;
								}

								// check if any dot is present
								public bool CheckAnyDot()
								{
												for ( int i = 0; i < _buffer.Length; i++ )
												{
																if ( _buffer[i] == DOT ) 
																{
																				return true;
																}
												}
												return false;
								}

								// get result
								public string GetResult()
								{
												if (_isResult)
												{
																_isResult = false;
																return _memory;
												}
												else
												{
																return _buffer;
												}
								}
				}
}
