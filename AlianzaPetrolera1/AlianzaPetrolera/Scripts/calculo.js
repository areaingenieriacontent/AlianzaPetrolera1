function sumar() {
    var matricula = $(Matricula).val();
    var poliza = $(Poliza).val();
    var uniforme = $(Uniforme).val();
    var mensualidad = $(Mensualidad).val();
    var descmatri = $(DescMatri).val();
    var descpoli = $(DescPoli).val();
    var descunif = $(DescUnif).val();
    var descmensu = $(DescMensu).val();
    var abonosuotros = $(Abonosuotros).val();

    var total = 0;

    var calmatri
    var finmatri
    var calpoli
    var finpoli
    var calunif
    var finunif
    var calmensu
    var finmensu



    calmatri = ((matricula * descmatri) / 100);
    finmatri = (matricula - calmatri);

    calpoli = ((poliza * descpoli) / 100);
    finpoli = (poliza - calpoli);

    calunif = ((uniforme * descunif) / 100);
    finunif = (uniforme - calunif);

    calmensu = ((mensualidad * descmensu) / 100);
    finmensu = (mensualidad - calmensu);

    abonosuotros = abonosuotros * 1;

    total = finmatri + finpoli + finunif + finmensu + abonosuotros;



    $(Total).val(total);
    $(CosMatri).val(finmatri);
    $(CosPoli).val(finpoli);
    $(CosUnif).val(finunif);
    $(CosMensu).val(finmensu);




}

function changesbank() {

    var select = document.getElementById("ModoPagos"), //El <select>
        text = select.options[select.selectedIndex].innerText;
    $(Reci_Mpago).val(text);

    var select1 = document.getElementById("Bancos"), //El <select>
        text1 = select1.options[select1.selectedIndex].innerText;
    $(Banco_Id).val(text1);

    var select2 = document.getElementById("pago_mes"),
        text2 = select2.options[select2.selectedIndex].innerText;
    $(pago_mes_id).val(select2);


}
function agregar() {

    document.getElementById("Text1").value = document.getElementById("Text2").value

}


function capturar() {

    var porId = document.getElementById("nombre").value;

    document.getElementById("resultado").innerHTML = porId;


    //var porId = document.getElementById("observaciones").value;
    //alert(porId);
    //$(observacio1n).val(porId);
}