using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin,string firstName,string lastName,double balance){
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getfName()
    {
        return firstName;
    }

    public string getlName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setfName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setlName (string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance (double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you your new balance is: " + currentUser);
        }

        void Withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdarw: ");
            double withdrawal = double.Parse(Console.ReadLine());
            if(currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficent balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Your good to go thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balnce is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4539230391367542", 1234 , "John","Griffith",150.31));
        cardHolders.Add(new cardHolder("4430034118662593", 4321 , "Ashely","Jones",310.54));
        cardHolders.Add(new cardHolder("4789492059455616", 9999 , "Frida","Dickerson",354.75));
        cardHolders.Add(new cardHolder("4485595885094123", 4271 , "Muneeb","HardKing",841.31));
        cardHolders.Add(new cardHolder("4539565513092431", 1984 , "Duan","Smith",54.31));

        // prompt user

        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please isnert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null){ break;}else{Console.WriteLine("Card not recognized please try again");}
            }
            catch
            {
                Console.WriteLine("Card not recognized please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //Check against our db
                    if(currentUser.getPin()== userPin){
                        break;
                    }else{
                        Console.WriteLine("Incorrect pin. Please try again");
                    }
                }catch{
                        Console.WriteLine("Incorrect pin. Please try again");
                    }
            }

            Console.WriteLine("Welcome " + currentUser.getfName() + " :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch{}
                if(option == 1){deposit(currentUser);}
                else if(option == 2){Withdraw(currentUser);}
                else if(option == 3) {balance(currentUser);}
                else if(option == 4){break;}
                else{
                    option = 0;
                }

            }
            while(option != 4);
            Console.WriteLine("Thank you have a nice day");
        }
    }

