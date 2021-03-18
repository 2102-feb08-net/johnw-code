function newCounter() {
    let num = 0;
    return function() {
        num++;
        return num;
    }
}

const counter = newCounter();
console.log(counter()); // 1
console.log(counter()); // 2
console.log(counter()); // 3
console.log(counter()); // 4
const counter2 = newCounter();
console.log(counter2()); // 1
console.log(counter2()); // 2
console.log(counter()); // 5