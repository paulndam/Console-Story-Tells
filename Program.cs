using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Page firstPage = new Page() {content = "Once upon a time ..."};
            Page secondPage = new Page() {content = "There he comes, furious, striking ..."};
            Page thirdPage = new Page() {content = "Oh , wait a second !!, who knew he was the Berkshire ...."};
            Page fourthPage = new Page() {content = "Hail , oh hail to the all mighty  ...."};
            Page fifthPage = new Page() {content = "In the evening, at lord vaughrd Ragnal ...."};
            Page sixthPage = new Page() {content = "In Valhala shall we meet, eat and wine together my brother ...."};

            LinkedList<Page> pages = new LinkedList<Page>();
            pages.AddLast(secondPage);

            LinkedListNode<Page> nodefourthPage = pages.AddLast(fourthPage);
            pages.AddLast(sixthPage);
            pages.AddFirst(firstPage);
            pages.AddBefore(nodefourthPage, thirdPage);
            pages.AddAfter(nodefourthPage, fifthPage);

            // now writing code to present it on page or console

            LinkedListNode<Page> current = pages.First;
            // the current variable represents the page that will be presented in the console currently
            // naming page 1 which is the initial value
            
            int number = 1;

            // stating here that as long as there's a next page, clear the current console page and then i will pass in the number for the next page using my number variable is initiated earlier.

            while(current != null){
                Console.Clear();
                string numberString = $"-{number} -";
                // page will be displayed into 2 lines and no more than 90  chars
                int leadingSpaces = (90 - numberString.Length) /2;
                // now showing the output
                Console.WriteLine(numberString.PadLeft(leadingSpaces + numberString.Length));
                Console.WriteLine();

                // now accessing my generic list , to do so, i will have to access thru their keir value

                string theContent = current.Value.content;

                for(int i = 0; i < theContent.Length; i+=90){
                    string line = theContent.Substring(i);
                    line = line.Length > 90 ? line.Substring(0, 90) : line;
                    Console.Write(line);
                }

                Console.WriteLine();
                Console.WriteLine($"Story tales from the Blue Library ");

                Console.WriteLine();

                // doing a sort of ternary operator, checking to see that as long as the previous page isn't null then we are gonna display the previous button or tab info and same as for the next page.

                Console.WriteLine(current.Previous != null ? "< PREVIOUS [P]" : GetSpaces(14));

                Console.WriteLine(current.Next != null ? "[N] NEXT >".PadLeft(76) : string.Empty);

                // now we switch in between our pages or content 

                switch(Console.ReadKey(true).Key){
                    case ConsoleKey.N:
                    if(current.Next != null){
                        current = current.Next;
                        number++;

                    }
                    break;
                    case ConsoleKey.P:
                    if(current.Previous != null){
                        current = current.Previous;
                        number--;

                    }
                    break;

                    default:
                    return;
                }

            }

            



        }

        // function that will return the string variable with the specified number of spaces.


        private static string GetSpaces(int number){

            string result = string.Empty;
            for(int i = 0; i < number; i++){
                result += " ";
            }

            return result;
        }
                    
                
    }
}
