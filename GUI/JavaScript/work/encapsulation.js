class BankAccount {
    customerName;
    accountNumber;
    #balance;

    constructor(customerName,balance=0){
    
        this.customerName =customerName;
        this.accountNumber = Date.now();
        this.#balance = balance;
    }

    deposite(amount){
        this.#balance += amount;
    }
    withdraw(amount){
        this.#balance -= amount;
    }

    // method  

    // setbalance(amount){
    //     if(isNaN(amount)){
    //         throw new Error('Amount is not valid input.')
    //     }
    //     this.#balance = amount;
    // }
    // property
    set balance(amount){
        if(isNaN(amount)){
            throw new Error('Amount is not valid input.')
        }
        this.#balance = amount;
    }
    get balance(){
        return this.#balance;
    }
}

class currentAccount extends BankAccount{

    constructor(customerName,balance=0){
        super(customerName,balance);

    }
    takePersonalLoan(amount){
        console.log("taking loan :" , amount);
    }
}

const b1 = new currentAccount("Ishika", 500)

//b1.#balance = 50000 // error because its private
// b1.setbalance("Hello") // throw error not valid type
b1.balance =5000
// b1.balance = 400
console.log(b1.balance)
b1.takePersonalLoan(9000)
console.log(b1)