var cifrar = document.querySelector("#btn-encriptar");
var descifrar = document.querySelector("#btn-desencriptar");
var copiado = document.querySelectorAll("#btn-copy");

function encriptar()
{
      var text = document.querySelector("#input-texto").value;
      var  textoEncriptado = text.replace(/e/g,"enter").replace(/i/g,"imes").replace(/a/g,"ai").replace(/o/g,"ober").replace(/u/g,"ufat");
      document.querySelector("#msg").value = textoEncriptado;
      document.querySelector("#input-texto").value;

}
cifrar.addEventListener("click",function(event){
    event.preventDefault();
    encriptar();
});
function desencriptar()
{
    var text = document.querySelector("#input-texto").value;
    var  textoDesencriptado = text.replace(/enter/g,"e").replace(/imes/g,"i").replace(/ai/g,"a").replace(/ober/g,"o").replace(/ufat/g,"u");
    document.querySelector("#msg").value = textoDesencriptado;
    document.querySelector("#input-texto").value;
}
descifrar.addEventListener("click",function(event){
    event.preventDefault();
    desencriptar();
})

function copiarTexto() {

    var contenido = document.querySelector("#msg");
    contenido.select();
    document.execCommand("copy");

    alert("Texto copiado en portapapeles!");
}