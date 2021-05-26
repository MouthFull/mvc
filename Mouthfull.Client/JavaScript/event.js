var input = [];

function addIngredient() {
  var node = document.createElement("LI");
  node.className = ""
  entry = document.getElementById("current-input").value;
  input.push(entry)
  var entryText = document.createTextNode(entry);
  node.appendChild(entryText);
  entry = "";
  document.getElementById("ingredient-list").appendChild(node);

}
function searchRecipes() {
  var form = document.getElementById("ingredient-input");
  var hiddenInput = document.getElementById("Input");
  hiddenInput.value = input.toString();
  console.log("inputSoFar: ", input);
  console.log("InputSubmitted: ", hiddenInput.value);
  form.submit();
}