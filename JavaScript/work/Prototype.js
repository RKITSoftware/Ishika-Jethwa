function BankAccount(customerName, balance = 0) {
    this.customerName = customerName;
    this.accountNumber = Date.now();
    this.balance = balance;
  
  }
  
  BankAccount.prototype.deposit = function(amount) {
    this.balance += amount;
  };
  BankAccount.prototype.withdraw = function(amount){
    this.balance -= amount;
  }
  // const rakesh = new BankAccount("rakesh",500)
  // rakesh.deposit(5000)
  // console.log(rakesh)
  
  const accounts = [];
  const accountform = document.getElementById("accountform");
  const customerName = document.getElementById("customerName");
  const balance = document.getElementById("balance");
  
//   const deposite = document.getElementById("deposite");
  const accountnumber = document.getElementById("accountnumber");
  const amount = document.getElementById("amount");
  const depo = document.getElementById("depo");
  const withdraw = document.getElementById("withdraw");
  
  
  accountform.addEventListener("submit", (e) => {
    e.preventDefault();
    const account = new BankAccount(customerName.value, +balance.value);
    accounts.push(account);
    console.log(accounts);
  });
  
  
  depo.addEventListener("click", (e) => {
    e.preventDefault();
    const account = accounts.find(
      (account) => account.accountNumber === +accountnumber.value
    );
    account.deposit(+amount.value);
    console.log(accounts); 
  });
  withdraw.addEventListener("click", (e) => {
    e.preventDefault();
    const account = accounts.find(
      (account) => account.accountNumber === +accountnumber.value
    );
    account.withdraw(+amount.value);
    console.log(accounts); 
  });
  