var file = document.getElementById("image-input");
var uploaded_image = "";

function inserirImagem() {
  file.click();

  file.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      uploaded_image = reader.result;
      document.getElementById(
        "output_image"
      ).style.backgroundImage = `url(${uploaded_image})`;
    });

    reader.readAsDataURL(this.files[0]);
  });
}

var file2 = document.getElementById("image-input2");
var uploaded_image2 = "";

function inserirImagem2() {
  file2.click();

  file2.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      uploaded_image = reader.result;
      document.getElementById(
        "output_image2"
      ).style.backgroundImage = `url(${uploaded_image})`;
    });

    reader.readAsDataURL(this.files[0]);
  });
}

var file3 = document.getElementById("image-input3");
var uploaded_image3 = "";

function inserirImagem3() {
  file3.click();

  file3.addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
      uploaded_image = reader.result;
      document.getElementById(
        "output_image3"
      ).style.backgroundImage = `url(${uploaded_image})`;
    });

    reader.readAsDataURL(this.files[0]);
  });
}
