firmaAdiInput =document.getElementById("firmaadi")
firmaTelefonInput =document.getElementById("firmatelefon")
firmaYetkiliAdiInput =document.getElementById("firmayetkiliadi")
firmaYetkiliTelefonInput =document.getElementById("firmayetkilitelefon")
adresNoInput =document.getElementById("adresno")
caddeAdiDropdown =document.getElementById("caddeButton")
sokakAdiDropdown =document.getElementById("sokakButton")
disKapiNoInput =document.getElementById("diskapino")
icKapiNoInput =document.getElementById("ickapino")
adaInput =document.getElementById("ada")
parselInput =document.getElementById("parsel")
tepeMusteriNoInput =document.getElementById("tepemusterino")
satisKaynagiAdiDropdown =document.getElementById("satisKaynagiButton")
satisTemsilcisiAdiDropdown =document.getElementById("satisTemsilcisiButton")
durumAdiDropdown =document.getElementById("durumButton")
farkliFirmaAdiDropdown =document.getElementById("farkliFirmaButton")
aciklamaInput =document.getElementById("aciklama")
coGorusmeDetayiInput =document.getElementById("cogorusmedetayi")
ostimGorusmeTarihiInput =document.getElementById("ostimgorusmetarihi")
ostimNotInput =document.getElementById("ostimnot")
firmaninAlarmIstemedigineDairYaziInput =document.getElementById("firmaninalarmistemediginedairyazi")
tepeGorusmeTarihiInput =document.getElementById("tepegorusmetarihi")
tepeNotInput =document.getElementById("tepenot")
paketTeslimDurumuAdiDropdown =document.getElementById("paketTeslimDurumuButton")
malzemeTeslimNoInput =document.getElementById("malzemeteslimno")
malzemeTeslimDurumuCheckbox =document.getElementById("malzemeteslimdurumu")
malzemeTeslimTarihiInput =document.getElementById("malzemeteslimtarihi")
kurulumDurumuCheckbox =document.getElementById("kurulumdurumu")
montajTarihiInput =document.getElementById("montajtarihi")
sahaRevizeNotInput =document.getElementById("saharevizenot")
sahaRevizeTarihiInput=document.getElementById("saharevizetarihi")
updateButton=document.getElementById("updateButton")
deleteButton=document.getElementById("deleteButton")
addButton=document.getElementById("addButton")

const urlParams = new URLSearchParams(window.location.search);
const firmaIdValue = urlParams.get('firmaId');
PrintFirmaComponents(firmaIdValue);
AllFirmasTable();
CaddeList();
SokakList();
SatisKaynagiList();
SatisTemsilcisiList();
DurumList();
FarkliFirmaList();
PaketTeslimDurumuList();

addButton.addEventListener("click", ()=>{
  window.location.href = "add.html"
})

updateButton.addEventListener("click",async()=>{
  const caddeResponse = await fetch('https://localhost:7269/api/cadde/getbycaddeadi?caddeAdi='+caddeAdiDropdown.innerText);
  const caddeJson = await caddeResponse.json();
  caddeData=caddeJson.data

  const sokakResponse = await fetch('https://localhost:7269/api/sokak/getbysokakadi?sokakAdi='+sokakAdiDropdown.innerText);
  const sokakJson = await sokakResponse.json();
  sokakData=sokakJson.data

  const durumResponse = await fetch('https://localhost:7269/api/durum/getbydurumadi?durumAdi='+durumAdiDropdown.innerText);
  const durumJson = await durumResponse.json();
  durumData=durumJson.data  

  const farkliFirmaResponse = await fetch('https://localhost:7269/api/farklifirma/getbyfarklifirmaadi?farkliFirmaAdi='+farkliFirmaAdiDropdown.innerText);
  const farkliFirmaJson = await farkliFirmaResponse.json();
  farkliFirmaData=farkliFirmaJson.data

  const satisKaynagiResponse = await fetch('https://localhost:7269/api/satiskaynagi/getbysatiskaynagiadi?satisKaynagiAdi='+satisKaynagiAdiDropdown.innerText);
  const satisKaynagiJson = await satisKaynagiResponse.json();
  satisKaynagiData=satisKaynagiJson.data

  const satisTemsilcisiResponse = await fetch('https://localhost:7269/api/satistemsilcisi/getbysatistemsilcisiadi?satisTemsilcisiAdi='+satisTemsilcisiAdiDropdown.innerText);
  const satisTemsilcisiJson = await satisTemsilcisiResponse.json();
  satisTemsilcisiData=satisTemsilcisiJson.data

  const paketTeslimDurumuResponse = await fetch('https://localhost:7269/api/paketteslimiadedurumu/getbypaketteslimiadedurumuadi?paketTeslimIadeDurumuAdi='+paketTeslimDurumuAdiDropdown.innerText);
  const paketTeslimDurumuJson = await paketTeslimDurumuResponse.json();
  paketTeslimDurumuData=paketTeslimDurumuJson.data

  const firmaUpdateResponse = await fetch('https://localhost:7269/api/firma/update', {
    method: 'POST',
    body: JSON.stringify({
      "id": firmaIdValue,
      "firmaAdi": firmaAdiInput.value,
      "firmaTelefonu": firmaTelefonInput.value,
      "yetkiliAdi": firmaYetkiliAdiInput.value,
      "yetkiliTelefonNo": firmaYetkiliTelefonInput.value,
      "adresNo": adresNoInput.value,
      "caddeId": caddeData.id,
      "sokakId": sokakData.id,
      "disKapiNo": disKapiNoInput.value,
      "icKapiNo": icKapiNoInput.value,
      "ada": adaInput.value,
      "parsel": parselInput.value,
      "tepeMusteriNo": tepeMusteriNoInput.value,
      "satisKaynagiId": satisKaynagiData.id,
      "satisTemsilcisiId": satisTemsilcisiData.id,
      "durumId": durumData.id,
      "farkliFirmaId": farkliFirmaData.id,
      "aciklama": aciklamaInput.value,
      "coGorusmeDetayi": coGorusmeDetayiInput.value,
      "ostimGorusmeTarihi": ostimGorusmeTarihiInput.value,
      "ostimNot": ostimNotInput.value,
      "firmaninAlarmIstemedigineDairYazi": firmaninAlarmIstemedigineDairYaziInput.value,
      "tepeGorusmeTarihi": tepeGorusmeTarihiInput.value,
      "tepeNot": tepeNotInput.value,
      "paketTeslimIadeDurumuId": paketTeslimDurumuData.id,
      "malzemeTeslimNo": malzemeTeslimNoInput.value,
      "malzemeTeslimDurumu": malzemeTeslimDurumuCheckbox.checked,
      "malzemeTeslimTarihi": malzemeTeslimTarihiInput.value,
      "kurulumDurumu": kurulumDurumuCheckbox.checked,
      "montajTarihi": montajTarihiInput.value,
      "sahaRevizeNot": sahaRevizeNotInput.value,
      "sahaRevizeTarihi": sahaRevizeTarihiInput.value
    }),
    headers: {
        'Content-type': 'application/json; charset=UTF-8',
    }
    })
  const firmaUpdateJson = await firmaUpdateResponse.json();
  if(firmaUpdateJson.success=false){
    console.log(firmaUpdateJson.message);
  }
})

deleteButton.addEventListener("click", async ()=>{
  const firmaResponse = await fetch('https://localhost:7269/api/firma/getbyid?id='+firmaIdValue);
  const firmaJson = await firmaResponse.json();
  firmaData=firmaJson.data

  const firmaDeleteResponse=await fetch('https://localhost:7269/api/firma/delete?id='+firmaData.id,{
    method: 'POST'
  });
  const firmaDeleteJson=await firmaDeleteResponse.json();
  if(firmaDeleteJson.success=false){
    console.log(firmaDeleteJson.message);
  }
})

async function PrintFirmaComponents(firmaIdValue){
  const firmaComponentsResponse = await fetch('https://localhost:7269/api/firma/getfirmacomponentsbyid?id='+firmaIdValue);
  const firmaComponentsJson = await firmaComponentsResponse.json();
  firmaComponentsData=firmaComponentsJson.data
  console.log(firmaComponentsData);

  adresNoInput.value=firmaComponentsData.adresNo
  disKapiNoInput.value=firmaComponentsData.disKapiNo
  icKapiNoInput.value=firmaComponentsData.icKapiNo
  adaInput.value=firmaComponentsData.ada
  parselInput.value=firmaComponentsData.parsel

  caddeAdiDropdown.innerText=firmaComponentsData.caddeAdi

  sokakAdiDropdown.innerText=firmaComponentsData.sokakAdi

  firmaAdiInput.value=firmaComponentsData.firmaAdi
  firmaTelefonInput.value=firmaComponentsData.firmaTelefonu
  ostimGorusmeTarihiInput.value=firmaComponentsData.ostimGorusmeTarihi
  aciklamaInput.value=firmaComponentsData.aciklama
  coGorusmeDetayiInput.value=firmaComponentsData.coGorusmeDetayi
  ostimNotInput.value=firmaComponentsData.ostimNot
  firmaninAlarmIstemedigineDairYaziInput.value=firmaComponentsData.firmaninAlarmIstemedigineDairYazi
  tepeMusteriNoInput.value=firmaComponentsData.tepeMusteriNo
  tepeGorusmeTarihiInput.value=firmaComponentsData.tepeGorusmeTarihi
  tepeNotInput.value=firmaComponentsData.tepeNot
  malzemeTeslimNoInput.value=firmaComponentsData.malzemeTeslimNo
  malzemeTeslimDurumuCheckbox.checked=firmaComponentsData.malzemeTeslimDurumu
  malzemeTeslimTarihiInput.value=firmaComponentsData.malzemeTeslimTarihi
  kurulumDurumuCheckbox.checked=firmaComponentsData.kurulumDurumu
  montajTarihiInput.value=firmaComponentsData.montajTarihi
  sahaRevizeNotInput.value=firmaComponentsData.sahaRevizeNot
  sahaRevizeTarihiInput.value=firmaComponentsData.sahaRevizeTarihi

  durumAdiDropdown.innerText=firmaComponentsData.durumAdi

  farkliFirmaAdiDropdown.innerText=firmaComponentsData.farkliFirmaAdi

  firmaYetkiliAdiInput.value=firmaComponentsData.firmaYetkiliAdi
  firmaYetkiliTelefonInput.value=firmaComponentsData.firmaYetkiliTelefonNo

  satisKaynagiAdiDropdown.innerText=firmaComponentsData.satisKaynagiAdi

  satisTemsilcisiAdiDropdown.innerText=firmaComponentsData.satisTemsilcisiAdi

  paketTeslimDurumuAdiDropdown.innerText=firmaComponentsData.paketTeslimIadeDurumuAdi
}

async function AllFirmasTable(){
    let table=document.getElementById("table");
    const allFirmaResponse = await fetch('https://localhost:7269/api/firma/getallfirmacomponents');
    const allFirmaJson = await allFirmaResponse.json();
    allFirmaData=allFirmaJson.data;
    generateTableHead(table,allFirmaData);
    generateTableBody(table,allFirmaData);
    console.log(allFirmaData);
}

async function CaddeList(){
  const caddeAllResponse = await fetch('https://localhost:7269/api/cadde/getall');
  const caddeAllJson = await caddeAllResponse.json();
  caddeAllData=caddeAllJson.data
  CreateCaddeList(caddeAllData);
}
function CreateCaddeList(caddeAllData){
  let ul=document.getElementById("caddeUl");
  i=1;
  for(let element of caddeAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="caddeLi-"+i
      i++;
      li.innerText=element.caddeAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("caddeButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function SokakList(){
  const sokakAllResponse = await fetch('https://localhost:7269/api/sokak/getall');
  const sokakAllJson = await sokakAllResponse.json();
  sokakAllData=sokakAllJson.data
  CreateSokakList(sokakAllData);
}
function CreateSokakList(sokakAllData){
  let ul=document.getElementById("sokakUl");
  i=1;
  for(let element of sokakAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="sokakLi-"+i
      i++;
      li.innerText=element.sokakAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("sokakButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function SatisKaynagiList(){
  const satisKaynagiAllResponse = await fetch('https://localhost:7269/api/satiskaynagi/getall');
  const satisKaynagiAllJson = await satisKaynagiAllResponse.json();
  satisKaynagiAllData=satisKaynagiAllJson.data
  CreateSatisKaynagiList(satisKaynagiAllData);
}
function CreateSatisKaynagiList(satisKaynagiAllData){
  let ul=document.getElementById("satisKaynagiUl");
  i=1;
  for(let element of satisKaynagiAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="satisKaynagiLi-"+i
      i++;
      li.innerText=element.satisKaynagiAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("satisKaynagiButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function SatisTemsilcisiList(){
  const satisTemsilcisiAllResponse = await fetch('https://localhost:7269/api/satistemsilcisi/getall');
  const satisTemsilcisiAllJson = await satisTemsilcisiAllResponse.json();
  satisTemsilcisiAllData=satisTemsilcisiAllJson.data
  CreateSatisTemsilcisiList(satisTemsilcisiAllData);
}
function CreateSatisTemsilcisiList(satisTemsilcisiAllData){
  let ul=document.getElementById("satisTemsilcisiUl");
  i=1;
  for(let element of satisTemsilcisiAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="satisTemsilcisiLi-"+i
      i++;
      li.innerText=element.satisTemsilcisiAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("satisTemsilcisiButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function DurumList(){
  const durumAllResponse = await fetch('https://localhost:7269/api/durum/getall');
  const durumAllJson = await durumAllResponse.json();
  durumAllData=durumAllJson.data
  CreateDurumList(durumAllData);
}
function CreateDurumList(durumAllData){
  let ul=document.getElementById("durumUl");
  i=1;
  for(let element of durumAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="durumLi-"+i
      i++;
      li.innerText=element.durumAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("durumButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function FarkliFirmaList(){
  const farkliFirmaAllResponse = await fetch('https://localhost:7269/api/farklifirma/getall');
  const farkliFirmaAllJson = await farkliFirmaAllResponse.json();
  farkliFirmaAllData=farkliFirmaAllJson.data
  CreateFarkliFirmaList(farkliFirmaAllData);
}
function CreateFarkliFirmaList(farkliFirmaAllData){
  let ul=document.getElementById("farkliFirmaUl");
  i=1;
  for(let element of farkliFirmaAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="farkliFirmaLi-"+i
      i++;
      li.innerText=element.farkliFirmaAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("farkliFirmaButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

async function PaketTeslimDurumuList(){
  const paketTeslimDurumuAllResponse = await fetch('https://localhost:7269/api/paketteslimiadedurumu/getall');
  const paketTeslimDurumuAllJson = await paketTeslimDurumuAllResponse.json();
  paketTeslimDurumuAllData=paketTeslimDurumuAllJson.data
  CreatePaketTeslimDurumuList(paketTeslimDurumuAllData);
}
function CreatePaketTeslimDurumuList(paketTeslimDurumuAllData){
  let ul=document.getElementById("paketTeslimDurumuUl");
  i=1;
  for(let element of paketTeslimDurumuAllData){
      let li=document.createElement("li");
      ul.appendChild(li);
      li.id="paketTeslimDurumuLi-"+i
      i++;
      li.innerText=element.paketTeslimIadeDurumuAdi;
      li.addEventListener("click", ()=>{
        button=document.getElementById("paketTeslimDurumuButton");
        button.innerText=li.innerText;
      });
      li.addEventListener("mouseenter", ()=>{
          li.style.cursor="pointer";
      });
  }   
}

function generateTableBody(table, data) {
    let tbody=document.getElementById("tbody");
    i=1;
      for (let element of data) {
        let row = tbody.insertRow();
        row.id="bodyrow-"+i;
        i++;
        row.addEventListener("click", () => {
          window.location.href = "main.html?firmaId="+element.firmaId+"";
        }); 
        row.addEventListener("mouseenter", () => {
          row.style.cursor = "pointer";
        });             
        for (key in element) {
          let cell = row.insertCell();
          text=document.createTextNode(element[key]);
          cell.appendChild(text);
        }
      }
    }

function generateTableHead(table, data) {
    let thead = document.getElementById("thead");
    let row = thead.insertRow();
    var keyNames=Object.keys(data[0])
    for(let i=0;i<keyNames.length;i++){
      let th=document.createElement("th");
      let text=document.createTextNode(keyNames[i]);
      th.appendChild(text);
      row.appendChild(th)
    }
  } 
