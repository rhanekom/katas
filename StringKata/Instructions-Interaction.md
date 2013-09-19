From: http://osherove.com/tdd-kata-2/.

The Kata
--------

1. Every time you call Add(string) it also outputs the number result of the calculation in a new line to the terminal or console. (remember to try and do this test first!)

2. Create a program (test first)that uses string calculator, which the user can invoke through the terminal/console by calling “scalc ‘1,2,3’” and will output the following line before exiting: “The result is 6”

3. Instead of exiting after the first result, the program will ask the user for “another input please” and print the result of the new user input out as well, until the user gives no input and just preses enter. in that case it will exit.
 

Hints:
------
 


1. How can you check if something was output to the console? in ruby you can just override the ‘puts’ method or use one of the isolation frameworks to fake it and check that it was called. in .NET, the Console class has a static method called “SetOut” that takes a text writer. combine that with a StringBuilder, and you have a built in way to create a mock that can check what was sent to the console. another option is to abstract the output medium completly into its own class or interface such as IOutput, that can be used to ‘mediate’ between the real console and the inputs and outputs. 

2. For test driving a console application, if you’re using .NET, you can test-first a public static Main(params string args[]) function which is the root of the console application. no need to create a new process in your tests 

3. For number 3, you will need to devise a way to “wait” for user input without really waiting for a real user. your test will need to give two seperate inputs to the program, and it shoudl run fast, and not wait for any manual interaciton from you. Think about how to do that.

4. Can’t think of a way? What if you were to extract a special method called GetNextUserInput() that returns the string the user has provided? then you can overide that method in your tests (using extract and override if you need to) and return “fake” user inputs to test the system. 