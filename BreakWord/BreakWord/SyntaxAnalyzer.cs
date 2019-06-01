using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakWord
{
    class SyntaxAnalyzer
    {
        Node CurrentToken;
        string cp;

        public string Output = "HI";


        public SyntaxAnalyzer(LinkList CopyList)
        {

            CurrentToken = CopyList.GetHead();
            cp = CurrentToken.GetClassPart();

        }


        public Do ABS()
        {
            Do ndo = new Do();


            if (Start())
            {
                ndo.cppp = "Valid Syntax";
                ndo.cpline = CurrentToken.LineNo;
                return ndo;
            }

            else
            {
                ndo.cppp = "InValid Syntax";
                ndo.cpline = CurrentToken.LineNo;
                return ndo;
            }


        }
        public bool Start()
        {
            if (cp == "NEWLINE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
            }

            if (Class_Null())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                }
                if (Main_Class())
                {
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                    }
                    if (Class_Null2())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }
                        return true;
                    }
                }

            }

            return false;
        }

        public bool Class_Null2()
        {
            if (Class_St() || Interface_St() || Abs_Class_St() || Obj_Class())
            {
                if (Class_Null2())
                {
                    return true;

                }
            }

            else if (cp == "$") { return true; }

            return false;

        }

        public bool Class_Null()
        {
            if (Class_St() || Interface_St() || Abs_Class_St() || Obj_Class())
            {
                if (Class_Null())
                {
                    return true;

                }
            }

            else if (cp == "MAIN") { return true; }

            return false;
        }

        public bool Main_Class()
        {
            if (cp == "MAIN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "CLASS")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }

                        if (Inher_Body())
                        {
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                            }
                            if (cp == "{")
                            {

                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                }
                                if (Main_Class_Body())
                                {
                                    if (cp == "NEWLINE")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                    }
                                    if (cp == "}")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                        return true;

                                    }

                                }

                            }
                        }

                    }

                }

            }
            return false;
        }

        public bool Inher_Body()
        {
            if (cp == "::")
            {

                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (Multi())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }
                        return true;

                    }


                }

            }
            else if (cp == "{" || cp == "NEWLINE") { return true; }

            return false;

        }

        public bool Multi()
        {
            if (cp == ",")
            {

                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {

                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Multi())
                    {

                        return true;

                    }
                }
            }
            else if (cp == "{" || cp == "NEWLINE") { return true; }

            return false;
        }

        public bool Main_Class_Body()
        {
            if (cp == "AM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();


                if (Class_Mst())
                {
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                    }
                    if (Main_Func())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }
                        if (Class_Mst11())
                        {
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                            }
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        public bool Class_Mst11()
        {
            if (Class_Sst11())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (Class_Mst11())
                    {
                        return true;

                    }


                }

            }
            else if (cp == "}") return true;
            return false;
        }
        public bool Class_Sst11()
        {
            if (cp == "AM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Class_Sst())
                {
                    return true;


                }

            }
            return false;
        }

        public bool Main_Func()
        {
            if (cp == "MAIN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "FUN")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        if (cp == "(")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                            if (Para_List())
                            {
                                if (cp == ")")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                    if (cp == "->")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();

                                        if (Return_Type())
                                        {
                                            if (cp == "NEWLINE")
                                            {
                                                CurrentToken = CurrentToken.Increment();
                                                cp = CurrentToken.GetClassPart();

                                            }
                                            if (cp == "{")
                                            {
                                                CurrentToken = CurrentToken.Increment();
                                                cp = CurrentToken.GetClassPart();


                                                if (cp == "NEWLINE")
                                                {
                                                    CurrentToken = CurrentToken.Increment();
                                                    cp = CurrentToken.GetClassPart();



                                                }

                                                if (Mst())
                                                {
                                                    if (cp == "}")
                                                    {
                                                        CurrentToken = CurrentToken.Increment();
                                                        cp = CurrentToken.GetClassPart();


                                                        return true;




                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }
                    }
                }

            }

            return false;
        }

        public bool Return_Type()
        {
            if (Dt_Id())
            {
                return true;
            }
            if (cp == "VOID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                return true;
            }
            return false;
        }
        public bool Para_List()
        {
            if (cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Null_Arr())
                {
                    if (cp == ":")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (Dt_Id1())
                        {

                            if (Para_List2())
                            {
                                return true;

                            }

                        }

                    }
                }

            }
            else if (cp == ")")
            { return true; }

            return false;
        }

        public bool Para_List2()
        {
            if (cp == ",")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Null_Arr())
                    {
                        if (cp == ":")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (Dt_Id1())
                            {
                                if (Para_List2())
                                {
                                    return true;

                                }

                            }


                        }

                    }
                }
            }

            else if (cp == ")") return true;


            return false;
        }
        public bool Null_Arr()
        {
            if (cp == "[")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "]")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    return true;
                }

            }
            else if (cp == ":" || cp == "{" || cp == "NEWLINE" ) return true;

            return false;
        }

        public bool Dt_Id()
        {
            if (cp == "DT" || cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Null_Arr())
                {
                    return true;

                }

            }
            return false;
        }

        public bool Declaration()
        {
            if (cp == "TYPE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();


                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Dynamic_Static())
                    {
                        if (Init())
                        {
                            return true;

                        }

                    }

                }
            }
            return false;
        }
        public bool Dynamic_Static()
        {
            if (cp == ":")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Dt_Id1())
                {
                    return true;
                }
            }
            else if (cp == "ASSIGNOP" || cp == "NEWLINE") return true; 
            return false;
        }
        public bool Init()
        {
            if (cp == "ASSIGNOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Exp())
                {
                    return true;
                }
            }
            else if (cp == "NEWLINE" ) return true;
            return false;
        }

        public bool Func_Dec()
        {
            if (Virt_Over_Null())
            {
                if (cp == "FUN")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        if (cp == "(")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                            if (Para_List())
                            {
                                if (cp == ")")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                    if (cp == "->")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                        if (Return_Type())
                                        {
                                            if (cp == "NEWLINE")
                                            {
                                                CurrentToken = CurrentToken.Increment();
                                                cp = CurrentToken.GetClassPart();
                                            }
                                            if (cp == "{")
                                            {
                                                CurrentToken = CurrentToken.Increment();
                                                cp = CurrentToken.GetClassPart();
                                                if (cp == "NEWLINE")
                                                {
                                                    CurrentToken = CurrentToken.Increment();
                                                    cp = CurrentToken.GetClassPart();
                                                }
                                                if (Mst())
                                                {

                                                    if (cp == "}")
                                                    {
                                                        CurrentToken = CurrentToken.Increment();
                                                        cp = CurrentToken.GetClassPart();

                                                        return true;
                                                    }

                                                }

                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return false;

        }
        public bool Virt_Over_Null()
        {
            if (cp == "VO")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                return true;

            }
            else if (cp == "FUN") { return true; }
            return false;
        }

        public bool Func_Call()
        {
            if (cp == "(")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Argument_Statement())
                {
                    if (cp == ")")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        return true;
                    }
                }
            }
            return false;

        }
        public bool Argument_Statement()
        {
            if (Exp())
            {
                if (Exp2())
                {
                    return true;
                }
            }
            else if (cp == ")" || cp=="}") return true;

            return false;
        }

        public bool Exp2()
        {
            if (cp == ",")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Exp())
                {
                    if (Exp2())
                    {
                        return true;
                    }
                }
            }
            else if (cp == ")" || cp=="}") return true;

            return false;
        }

        public bool Return_St()
        {
            if (cp == "RETURN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Exp())
                {
                    return true;
                }

            }
            return false;
        }
        public bool Continue_St()
        {
            if (cp == "CONTINUE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Exp())
                {
                    return true;
                }

            }
            return false;

        }

        public bool Break_St()
        {
            if (cp == "BREAK")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Exp())
                {
                    return true;
                }

            }
            return false;
        }

        public bool While_St()
        {
            if (cp == "WHILE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                }
                if (cp == "(")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                    }
                    if (Exp())
                    {

                        if (cp == ")")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                            }
                            if (Body())
                            {

                                return true;

                            }

                        }

                    }

                }
            }
            return false;

        }
        public bool Do_While_St()
        {
            if (cp == "DO")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                }
                if (cp == "{")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                    }
                    if (Mst())
                    {

                        if (cp == "}")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                            }
                            if (cp == "WHILE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                                if (cp == "(")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();

                                    if (Exp())
                                    {

                                        if (cp == ")")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();

                                            return true;

                                        }

                                    }

                                }

                            }

                        }

                    }

                }


            }

            return false;
        }

        public bool For_St()
        {
            if (cp == "FOR")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "(")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (C1())
                    {
                        if (cp == "|")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (C2())
                            {
                                if (cp == "|")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();

                                    if (C3())
                                    {
                                        if (cp == ")")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();
                                            if (cp == "NEWLINE")
                                            {
                                                CurrentToken = CurrentToken.Increment();
                                                cp = CurrentToken.GetClassPart();
                                            }
                                            if (Body())
                                            {
                                                return true;

                                            }

                                        }

                                    }

                                }

                            }

                        }


                    }

                }

            }
            return false;

        }
        public bool C1()
        {

            if (cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (LeftFact())
                {
                    return true;

                }
            }
            else if (cp == "|" || cp==")") return true;

            return false;
        }

        public bool LeftFact()
        {
            if (cp == ":")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Dt_Id1())
                {
                    if (Exp())
                    {
                        return true;
                    }

                }
            }
            if (Assign() || Func_Call())
            {
                return true;


            }

            return false;

        }
        public bool C2()
        {
            if (Exp())
            {
                return true;

            }
            else if (cp == "|") return true;
            return false;

        }


        public bool C3()
        {
            if (Inc_Dec_St() || C1())
            {
                return true;

            }

            else if (cp == ")") return true;

            return false;


        }

        public bool When_St()
        {
            if (cp == "WHEN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "(")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (Exp())
                    {
                        if (cp == ")")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                            }
                            if (cp == "{")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();

                                }
                                if (Case_Body())
                                {
                                    if (Else_Body())
                                    {
                                        if (cp == "}")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();
                                            return true;
                                        }
                                    }

                                }

                            }

                        }
                    }
                }
            }
            return false;
        }
        public bool Case_Body()
        {
            if (Exp())
            {
                if (cp == "->")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                    }
                    if (Body())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();


                        }
                        if (Case_Body())
                        {
                            return true;

                        }

                    }

                }
            }
            else if (cp == "ELSE") return true;

            return false;

        }

        public bool Id_IntConst()
        {
            if (cp == "ID" || cp == "INT_CONST")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                return true;

            }
            return false;

        }
        public bool Else_Body()
        {
            if (cp == "ELSE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "->")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                    }
                    if (Body())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                        }
                        return true;
                    }

                }

            }
            return false;

        }

        public bool If_St()
        {
            if (cp == "IF")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "(")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Exp())
                    {
                        if (cp == ")")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();


                            }

                            if (Body())
                            {

                                if (Else_St())
                                {
                                    return true;
                                }
                            }

                        }
                    }
                }
            }
            return false;
        }
        public bool Else_St()
        {
            if (cp == "ELSE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();


                }
                if (Body())
                {
                    return true;
                }
            }
            else if (cp == "NEWLINE")
            {
                return true;
            }
            return false;


        }


        public bool Array_Dec()
        {
            if (cp == "ARR")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "[")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (cp == "]")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (cp == ":")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                                if (Dt_Id1())
                                {


                                    if (Array_Assign())
                                    {
                                        return true;
                                    }

                                }

                            }

                        }

                    }
                }
            }
            return false;
        }

        public bool Array_Assign()
        {
            if (cp == "ASSIGNOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "[")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Exp())
                    {

                        if (cp == "]")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (Block())
                            {
                                return true;
                            }

                        }

                    }

                }

            }
            return false;
        }
        public bool Block()
        {
            if (cp == "{")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Argument_Statement())
                {
                    if (cp == "}")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        return true;
                    }
                }



            }
            else if (cp == "NEWLINE") 
            {
                return true;
            }
            return false;

        }

        public bool Const_List()
        {
            if (cp == "INT_CONST" || cp == "CHAR_CONST" || cp == "STRING_CONST" || cp == "FLOAT_CONST" || cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Const_List2())
                {
                    return true;

                }

            }
            return false;
        }
        public bool Const_List2()
        {
            if (cp == ",")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "INT_CONST" || cp == "CHAR_CONST" || cp == "STRING_CONST" || cp == "FLOAT_CONST" || cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (Const_List2())
                    {
                        return true;

                    }
                }

            }
            else if (cp == "}") return true;

            return false;
        }


        public bool Class_St()
        {
            if (Open_Null())
            {
                if (cp == "CLASS")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }

                        if (Inher_Body())
                        {
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                            }
                            if (cp == "{")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                }

                                if (Class_Mst11())
                                {
                                    if (cp == "}")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                        if (cp == "NEWLINE")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();
                                        }
                                        return true;

                                    }

                                }

                            }

                        }

                    }

                }

            }

            return false;
        }

        public bool Open_Null()
        {
            if (cp == "OPEN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                return true;

            }
            else if (cp == "CLASS") { return true; }// sdfsdfsdfsdf

            return false;
        }
        public bool Constructor_St()
        {
            if (cp == "CONSTRUCTOR")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();


                }
                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "(")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (Para_List())
                        {
                            if (cp == ")")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();


                                }
                                if (cp == "{")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                    if (cp == "NEWLINE")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();


                                    }
                                    if (Mst())
                                    {
                                        if (cp == "}")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();

                                            return true;

                                        }

                                    }



                                }


                            }
                        }
                    }

                }

            }

            return false;

        }
        public bool Abs_Class_St()
        {
            if (cp == "ABSTRACT")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                }

                if (cp == "CLASS")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }

                        if (Inher_Body())
                        {
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                            }
                            if (cp == "{")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                }
                                if (Abs_Body())
                                {
                                    if (cp == "NEWLINE")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                    }
                                    if (cp == "}")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                        if (cp == "NEWLINE")
                                        {
                                            CurrentToken = CurrentToken.Increment();
                                            cp = CurrentToken.GetClassPart();

                                        }
                                        return true;

                                    }

                                }

                            }
                        }

                    }

                }

            }
            return false;

        }

        public bool Abs_Body()
        {
            if (cp == "AM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Normal())
                {
                    if (Abs_Func())
                    {
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (Abs_Normal())
                            {
                                return true;

                            }
                        }

                    }

                }
            }
            return false;


        }

        public bool Normal()
        {
            if (Normal2())
            {
                if (cp == "AM")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Normal())
                    {
                        return true;

                    }
                }
            }

            else if (cp == "ABSTRACT")
            {
                return true;
            }

            return false;

        }

        public bool Normal2()
        {
            if (Func_Dec() || Declaration() || Array_Dec())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    return true;
                }

            }
            return false;
        }
        public bool Abs_Normal()
        {
            if (cp == "AM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (A1())
                {
                    if (Abs_Normal())
                    {
                        return true;

                    }

                }

            }
            else if (cp == "}") { return true; }

            return false;
        }

        public bool A1()
        {
            if (Abs_Func() || Func_Dec() || Declaration() || Constructor_St() || Array_Dec())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    return true;

                }

            }
            return false;

        }
        public bool Abs_Func()
        {
            if (cp == "ABSTRACT")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "FUN")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (cp == "(")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                            if (Para_List())
                            {
                                if (cp == ")")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                    if (cp == "->")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();
                                        if (Return_Type())
                                        {
                                            return true;
                                        }

                                    }
                                }

                            }

                        }

                    }

                }

            }
            return false;

        }
        public bool Interface_St()
        {
            if (cp == "INTERFACE")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                    }

                    if (cp == "{")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();
                        }

                        if (Interface_Body())
                        {
                            if (cp == "NEWLINE")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                            }
                            if (cp == "}")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "MEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                }
                                return true;

                            }

                        }


                    }

                }


            }
            return false;

        }

        public bool Interface_Body()
        {
            if (cp == "AM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (Abs_Func())
                {
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (Interface_Body())
                        {
                            return true;

                        }
                    }
                }

            }
            else if (cp == "}" ) { return true; }
            return false;
        }

        public bool Obj_Class()
        {
            if (cp == "OBJECT")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "NEWLINE")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                    }
                    if (cp == "{")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        if (cp == "NEWLINE")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                        }
                        if (Class_Mst())
                        {
                            if (cp == "}")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();
                                if (cp == "NEWLINE")
                                {
                                    CurrentToken = CurrentToken.Increment();
                                    cp = CurrentToken.GetClassPart();
                                }
                                return true;
                            }

                        }

                    }

                }

            }

            return false;

        }
        public bool Obj_Dec()
        {
            if (cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ASSIGNOP")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "NEW")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (cp == "ID")
                        {
                            CurrentToken = CurrentToken.Increment();
                            cp = CurrentToken.GetClassPart();

                            if (cp == "(")
                            {
                                CurrentToken = CurrentToken.Increment();
                                cp = CurrentToken.GetClassPart();

                                if (Argument_Statement())
                                {
                                    if (cp == ")")
                                    {
                                        CurrentToken = CurrentToken.Increment();
                                        cp = CurrentToken.GetClassPart();

                                        return true;

                                    }

                                }

                            }

                        }

                    }

                }


            }
            return false;

        }
        public bool Obj_Access()
        {
            if (cp == "DOTOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Fact())
                    {
                        if (Assign())
                        {
                            return true;
                        }

                    }

                }

            }
            return false;
        }
        public bool Fact()
        {
            if (cp == "DOTOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Id3())
                    {
                        return true;

                    }

                }


            }
            else if (Func_Call() || Array_Access())
            {
                if (Id3())
                {
                    return true;
                }
            }
            else if (cp == "ASSIGNOP" || cp == "COMPOUND_ASSIGN" || cp == "MDM" || cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == "NEWLINE" || cp == "," || cp == ")" || cp == "|" || cp == "]" || cp=="->")
            {
                return true;
            }

            return false;
        }
        public bool Id3()
        {
            if (cp == "DOTOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Abc())
                    {
                        if (Id3())
                        {
                            return true;

                        }

                    }

                }

            }
            else if (cp == "ASSIGNOP" || cp == "COMPOUND_ASSIGN" || cp == "MDM" || cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" ||cp=="->" ||cp=="]") { return true; }

            return false;
        }
        public bool Abc()
        {
            if (Func_Call() || Array_Access())
            {
                return true;

            }
            else if (cp == "DOTOP" || cp == "ASSIGNOP" || cp == "COMPOUND_ASSIGN" || cp == "MDM" || cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") { return true; }

            return false;
        }
        public bool Obj_Access2()
        {
            if (cp == "DOTOP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (Fact())
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        public bool Array_Access()
        {
            if (cp == "[")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Exp())
                {
                    if (cp == "]")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        return true;

                    }
                }
            }
            return false;

        }

        public bool This_St2()
        {
            if (cp == "THIS")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "DOTOP")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (This_Choice())
                        {
                            return true;

                        }

                    }
                }


            }
            return false;
        }

        public bool This_St()
        {
            if (cp == "THIS")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "DOTOP")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "ID")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (This_Choice())
                        {
                            if (Assign())
                            {
                                return true;

                            }

                        }

                    }
                }


            }
            return false;
        }


        public bool This_Choice()
        {
            if (Func_Call() || Array_Access())
            {
                return true;
            }
            else if (cp == "ASSIGNOP" || cp == "COMPOUND_ASSIGN" || cp == "MDM" || cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") { return true; }//sdfsdfsdfsdf
            return false;
        }
        public bool Body()
        {
            if (Sst())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    return true;
                }
            }
            else if (cp == "{")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                }

                if (Mst())
                {
                    if (cp == "}")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        return true;

                    }

                }

            }
            return false;
        }
        public bool Mst()
        {
            if (Sst())
            {


                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (Mst())
                    {
                        return true;
                    }
                }

            }
            else if (cp == "}") return true;

            return false;

        }

        public bool Sst()
        {
            if (cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Sst2())
                {
                    return true;
                }
                return false;

            }

            if (Declaration())
            {
                return true;
            }

            if (Array_Dec())
            {
                return true;
            }


            if (Return_St())
            {
                return true;
            }


            if (Continue_St())
            {
                return true;
            }


            if (Break_St())
            {
                return true;
            }


            if (While_St())
            {
                return true;
            }


            if (Do_While_St())
            {
                return true;
            }


            if (For_St())
            {
                return true;
            }
            if (Inc_Dec_St())
            {
                return true;

            }

            if (When_St())
            {
                return true;

            }
            if (If_St())
            {
                return true;
            }
            if (This_St())
            {
                return true;
            }


            return false;

        }
        public bool Sst2()
        {
            if ((Func_Call() && Dot()) || Assign() || Obj_Access() || Obj_Dec() || (Array_Access() && Dot2()))
            {
                return true;
            }
            return false;

        }
        public bool Dot()
        {
            if (Obj_Access())
            {
                return true;

            }
            else if (cp == "NEWLINE") { return true; }

            return false;

        }
        public bool Dot2()
        {
            if (Obj_Access() || Assign())
            {
                return true;

            }
            return false;

        }

        public bool Assign()
        {
            if (Assign_Op())
            {
                if (Exp())
                {
                    return true;
                }

            }
            return false;

        }
        public bool Assign_Op()
        {
            if (cp == "ASSIGNOP" || cp == "COMPOUND_ASSIGN")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                return true;

            }
            return false;

        }

        public bool Inc_Dec_St()
        {
            if (cp == "INCDEC")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (cp == "ID")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();

                    if (cp == "BY")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (Id_IntConst())
                        {

                            return true;

                        }

                    }
                }

            }
            return false;
        }

        public bool Class_Mst()
        {
            if (Class_Sst())
            {
                if (cp == "NEWLINE")
                {
                    CurrentToken = CurrentToken.Increment();
                    cp = CurrentToken.GetClassPart();
                    if (cp == "AM")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();

                        if (Class_Mst())
                        {
                            return true;
                        }
                    }
                }
            }
            else if (cp == "}" || cp == "MAIN") { return true; }
            return false;

        }
        public bool Class_Sst()
        {
            if (Declaration() || Func_Dec() || Array_Dec() || Constructor_St())
            {
                return true;
            }
            return false;
        }

        



        public bool Exp()
        {
            if (T())
            {
                if (ExpComma())
                {
                    return true;
                }

            }
            return false;


        }
        public bool ExpComma()
        {
            if (cp == "OR")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();
                if (T())
                {
                    if (ExpComma())
                    {
                        return true;
                    }
                }

            }
            else if ( cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]")                 return true;

            return false;
        }

        public bool T()
        {
            if (S())
            {
                if (TComma())
                {
                    return true;
                }
            }
            return false;


        }
        public bool TComma()
        {
            if (cp == "AND")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (S())
                {
                    if (TComma())
                    {
                        return true;

                    }
                }

            }
            else if (cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") return true;

            return false;

        }
        public bool S()
        {
            if (V())
            {
                if (SComma())
                {
                    return true;
                }
            }
            return false;
        }

        public bool SComma()
        {
            if (cp == "ROP")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (V())
                {
                    if (SComma())
                    {
                        return true;
                    }
                }

            }
            else if ( cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") return true;
            return false;

        }
        public bool V()
        {
            if (A())
            {
                if (VComma())
                {
                    return true;
                }
            }
            return false;

        }
        public bool VComma()
        {
            if (cp == "PM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (A())
                {
                    if (VComma())
                    {
                        return true;
                    }

                }

            }
            else if (cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") return true;

            return false;

        }
        public bool A()
        {
            if (Z())
            {
                if (ACOmma())
                {
                    return true;
                }
            }
            return false;

        }
        public bool ACOmma()
        {
            if (cp == "MDM")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Z())
                {
                    if (ACOmma())
                    {
                        return true;

                    }
                }
            }
            else if (cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") return true; return false;

        }
        public bool Z()
        {
            if (Const())
            {
                return true;
            }
           else if (cp == "NOT")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Z())
                {
                    return true;
                }
            }

           else if (cp == "ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (ZZ())
                {
                    return true;
                }

            }

            else if (cp == "(")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                if (Exp())
                {
                    if (cp == ")")
                    {
                        CurrentToken = CurrentToken.Increment();
                        cp = CurrentToken.GetClassPart();
                        return true;

                    }

                }

            }
            else if(Inc_Dec_St())
            {
                return true;

            }
            else if(This_St2())
            {
                return true;

            }

            return false;
        }
        public bool ZZ()
        {
            if (Func_Call() || Obj_Access2() || (Array_Access()&& Obj_Access_Null()))
            {
                return true;
            }
            else if (cp == "MDM" || cp == "PM" || cp == "ROP" || cp == "AND" || cp == "OR" || cp == ")" || cp == "NEWLINE" || cp == "," || cp == "}" || cp == "|" || cp == "->" || cp == "]") return true;  //sadvsadvadf

            return false;
        }

        public bool Const()
        {
            if (cp == "INT_CONST" || cp == "STRING_CONST" || cp == "FLOAT_CONST" || cp == "CHAR_CONST" || cp == "BOOL_CONST")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                return true;


            }
            return false;
        }

        public bool Obj_Access_Null()
        {
            if (Obj_Access2())
            {
                return true;
            }
            else if (cp=="MDM"||cp=="PM"||cp=="ROP"||cp=="AND"||cp=="OR"||cp=="NEWLINE"||cp=="DOTOP" ||cp==","||cp==")" ||cp=="|"||cp=="]") { return true; }

            return false;

        }

        public bool Dt_Id1()
        {
            if(cp=="DT" ||cp=="ID")
            {
                CurrentToken = CurrentToken.Increment();
                cp = CurrentToken.GetClassPart();

                return true;

            }
            return false;
        }


    }
}