function countAandB(input) {
  let count = 0;
  for (let i in input) {
    if (input[i] === "a" || input[i] === "b") {
      count += 1;
    }
  }
  return count;
}

//let 宣告為區域變數，可以再修改
//const 宣告一個變數值，且為固定不得再修改
//==為相等，===為嚴格相等（此時如果拿值跟字元比可能就會出錯）

function toNumber(input) {
  let dict = {
    a: 1,
    b: 2,
    c: 3,
    d: 4,
    e: 5,
  };
  result = [];
  for (let i in input) {
    key = input[i];
    if (dict.hasOwnProperty(key)) {
      result.push(dict[key]);
    }
  }
  return result;
}

let input1 = ["a", "b", "c", "a", "c", "a", "c"];
console.log(countAandB(input1));
console.log(toNumber(input1));

let input2 = ["e", "d", "c", "d", "e"];
console.log(countAandB(input2));
console.log(toNumber(input2));
