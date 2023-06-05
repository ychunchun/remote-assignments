function changeText() {
  let welcomeMessage = document.querySelector(".welcome_message");
  welcomeMessage.innerText = "Have a Good Time!";
}

function showContent() {
  var content = document.querySelectorAll(".showbox");
  content.forEach(function (box) {
    box.style.display = "block";
  });
}
