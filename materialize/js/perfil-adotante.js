
var file = document.getElementById("image-input");
var uploaded_image ="";

function inserirImagem(){

    file.click();

    file.addEventListener("change", function(){

    


        const reader = new FileReader();

        reader.addEventListener("load", () => {

            uploaded_image = reader.result;
            document.getElementById("output_image").style.backgroundImage = `url(${uploaded_image})`;
        });

        reader.readAsDataURL(this.files[0]);

    });
}

