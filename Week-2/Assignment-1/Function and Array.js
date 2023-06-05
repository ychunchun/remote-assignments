function max(numbers) {
  let bigger = numbers[0];
  for (let i = 1; i < numbers.length; i++) {
    if (numbers[i] > bigger) {
      bigger = numbers[i];
    }
  }
  return bigger;
}

function findPosition(numbers, target) {
  for (let i = 0; i < numbers.length; i++) {
    if (numbers[i] == target) {
      return i; //不需要加上break，因為執行return後，迴圈及結束
    }
  }
  return -1;
}

console.log(max([1, 2, 4, 5]));
console.log(max([5, 2, 7, 1, 6]));

console.log(findPosition([5, 2, 7, 1, 6], 5));
console.log(findPosition([5, 2, 7, 1, 6], 7));
console.log(findPosition([5, 2, 7, 7, 7, 1, 6], 7));
console.log(findPosition([5, 2, 7, 1, 6], 8));
