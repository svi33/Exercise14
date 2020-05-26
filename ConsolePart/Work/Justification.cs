using System;
using System.Text;

public static class Justification
{
	public static string startJust( string inputStr, int widthStr)
    {
        string temp = inputStr;
        int j = 0;
        
        while (temp.Length / widthStr - j > 0)
        {
            int move = widthStr;
            j++;
            for (int i = j * widthStr; i >= (j - 1) * widthStr; i--)
            {
                if (temp[i]==' ' && temp[i-1]!=' ')
                {
                    move = i - ((j - 1) * widthStr);
                    break;
                }
            }
            //select work area
            string change = temp.Substring((j - 1) * widthStr, move);

            //justification it
            int k = 0;
            while (change.Length<widthStr)
            {
                if (change[k] == ' ')
                {
                    change = change.Insert(k, " "); k+=2;
                    while (k < change.Length && change[k] == ' ')
                    { k++; }
                }
                else k++;
                if (k >= change.Length) k = 0;
            }
            
            change = change.Insert(widthStr, "\n");
            string last = temp.Remove(0, (j - 1) * widthStr + move);
            temp = temp.Remove((j - 1) * widthStr);

            //remove spaces from the start of new line
            k = 0;
            for (int i = 0; i < last.Length; i++)
            {
                if (last[i] == ' ') k++;
                else break;
            }
            last = last.Remove(0,k);

            temp = temp + change + last;
        }

        return temp;
    }

    public static string doJust(string inputStr, int widthStr)
    {
        StringBuilder result = new StringBuilder();
        string[] words = inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int countWorld = words.Length;

        StringBuilder temp = new StringBuilder();
        int j = 0;
        for (int i=0;i<countWorld;i++)
        {
            j += words[i].Length;
            if (j<=widthStr)
            {
                temp = temp.Append(words[i]);
                if (i == countWorld - 1)
                {
                    result = result.Append(temp);
                    return result.ToString();
                }
                temp = temp.Append(' ');
                j++;
            }
            else 
            {
                while (temp[temp.Length - 1] == ' ') 
                {
                    temp.Remove(temp.Length - 1, 1);
                }
                if (!temp.ToString().Contains(' '))
                {
                    while (temp.Length < widthStr)
                    {
                        temp.Insert(0, ' ');
                        if (temp.Length == widthStr)
                            break;
                        temp.Append(' ');
                    }
                }
                //justification it
                int k = 0;
                while (temp.Length < widthStr)
                {
                    if (temp[k] == ' ')
                    {
                        temp = temp.Insert(k, ' ');
                        while(k<=temp.Length && temp[k]==' ')
                        { k++; }
                    }
                   else 
                        k++;
                    if (k >= temp.Length) k = 0;
                }
                temp.Append("\n");
                j = words[i].Length+1;
                result = result.Append(temp);
                
                temp = new StringBuilder(words[i]+" ");
                if (i == countWorld - 1)
                {
                    temp.Remove(temp.Length - 1, 1);
                    result = result.Append(temp);
                    return result.ToString();
                }
            }
        }

        return result.ToString();
    }

}
