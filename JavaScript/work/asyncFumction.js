function syncFunction() {
    console.log("Sync function started");
    for (let i = 0; i < 1000000000; i++) {
        // Simulating some time-consuming task
    }
    console.log("Sync function completed");
}

console.log("Before calling syncFunction");
syncFunction();
console.log("After calling syncFunction");




async function asyncFunction() {
    console.log("Async function started");
    await new Promise(resolve => setTimeout(resolve, 1000)); // Simulating an async operation
    console.log("Async function completed");
}

console.log("Before calling asyncFunction");
asyncFunction().then(() => {
    console.log("Promise resolved");
});
console.log("After calling asyncFunction");
