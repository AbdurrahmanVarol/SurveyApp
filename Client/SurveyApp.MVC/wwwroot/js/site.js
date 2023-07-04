// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const checkQuestionType = event => {

    let questionId = event.target.value

    console.log(questionId)
    let div = document.getElementById('optionDiv')

    let isDisabled = [3, 4, 5].some(p => p == questionId)
     let a = 5
    console.log(isDisabled)

    if (isDisabled) {
        div.classList.add('disabled')
    }
    else {
        div.classList.remove('disabled')
    }

}