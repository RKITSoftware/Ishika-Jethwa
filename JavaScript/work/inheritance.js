class BankAccount {
    customerName;
    accountNumber;
    balance;

    constructor(customerName,balance=0){
        this.customerName =customerName;
        this.accountNumber = Date.now();
        this.balance = balance;
    }

    deposite(amount){
        this.balance += amount;
    }
    withdraw(amount){
        this.balance -= amount;
    }
}

class currentAccount extends BankAccount{
    // transitionlimit = 10000;
    constructor(customerName,balance=0){
        super(customerName,balance);

    }
    takePersonalLoan(amount){
        console.log("taking loan :" , amount);
    }
}

const b1 = new currentAccount("Ishika", 500)
b1.deposite(5000)
b1.withdraw(100)
b1.takePersonalLoan(9000)
console.log(b1)