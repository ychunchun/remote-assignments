function count(input) {
  let alphabet = {};
  for (let i = 0; i < input.length; i++) {
    if (alphabet[input[i]]) {
      //若當前字元出現在alphabet當中，為之前已經出現過，＋１
      alphabet[input[i]] += 1;
    } else {
      //若沒出現過，則將字元加入alphabet，並給予預設值１
      alphabet[input[i]] = 1;
    }
  }
  return alphabet;
}

let input1 = ["a", "b", "c", "a", "c", "a", "x"];
console.log(count(input1));

function groupByKey(input) {
  let char = {};
  for (let j = 0; j < input.length; j++) {
    if (char[input[j].key]) {
      char[input[j].key] += input[j].value;
    } else {
      char[input[j].key] = input[j].value;
    }
  }
  return char;
}

let input2 = [
  { key: "a", value: 3 },
  { key: "b", value: 1 },
  { key: "c", value: 2 },
  { key: "a", value: 3 },
  { key: "c", value: 5 },
];

console.log(groupByKey(input2));
