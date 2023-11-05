function getcheese(){
    return new Promise((resolve , reject) => {
        setTimeout(()=>{
            const cheese = "cheese";
            resolve(cheese)
        },2000);
    });
}
function makeDough(cheese){
    return new Promise((resolve , reject) => {
        setTimeout(()=>{
            const Dough = cheese + "Dough";
            resolve(Dough)
        },2000);
    });
}
function BakePizza(Dough){
    return new Promise((resolve , reject) => {
        setTimeout(()=>{
            const pizza = Dough + "Pizza";
            resolve(pizza)
        },2000);    
    });
}

// getcheese().then((cheese)=>{
//     console.log("Here is cheese" , cheese )
//     return makeDough(cheese)
// }).then((Dough)=>{
//     console.log("here is Dough...", Dough)
//     return BakePizza(Dough)
// }).then((pizza)=>{
//     console.log("Pizza is ready....", pizza)
// }).catch((data)=>{
//     console.log("error occured", data)
// }).finally(()=>{
//     console.log("always executed")
// })

async function orderPizza(){
    try {
        
        const cheese = await getcheese()
        console.log("Here is cheese..", cheese)
        const dough = await makeDough(cheese)
        console.log("Dough...." , dough)
        const pizza = await BakePizza(dough)
        console.log("pizza......", pizza)
    } catch (error) {
            console.log("Error occured")
    }
    
}

orderPizza()