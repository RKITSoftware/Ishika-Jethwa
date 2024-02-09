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

const b1 = new BankAccount("Ishika" , undefined)
// b1.deposite(5000)
// b1.withdraw(100)
console.log(b1)