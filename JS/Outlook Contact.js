function queryContact() {
    let ret = [];

    let element = document.getElementById("divContactCont");
    let node = element.querySelectorAll("table.staff");

    for (let i = 0; i < node.length; ++i) {
        let person = node[i].querySelectorAll("td");
        ret.push({
            name: person[0].innerText,
            job: person[1].innerText,
            account: person[2].innerText,
            mail: person[3].innerText.trim().replace(",", ".")
        });
    }
    return ret;
}

function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const header = "頭銜,名字,中間名,姓氏,稱謂,公司,部門,職稱,商務 - 街,商務 - 街 2,商務 - 街 3,商務 - 市/鎮,商務 - 縣/市,商務 - 郵遞區號,商務 - 國家/地區,住家 - 街,住家 - 街 2,住家 - 街 3,住家 - 市/鎮,住家 - 縣/市,住家 - 郵遞區號,住家 - 國家/地區,其他 - 街,其他 - 街 2,其他 - 街 3,其他 - 市/鎮,其他 - 縣/市,其他 - 郵遞區號,其他 - 國家/地區,助理電話,商務傳真,商務電話,商務電話 2,回撥電話,汽車電話,公司代表線,住家傳真,住家電話,住家電話 2,ISDN,行動電話,其他傳真,其他電話,呼叫器,代表電話,無線電話,TTY/TDD 電話,Telix,子女,介紹人,公司 ID,公司地址郵政信箱,主管名稱,生日,目錄伺服器,地點,住家地址郵政信箱,助理,私人,身份證字號,使用者 1,使用者 2,使用者 3,使用者 4,其他地址郵政信箱,性別,津貼,紀念日,記事,配偶,專業,帳戶,帳目資訊,敏感度,嗜好,電子郵件地址,電子郵件類型,電子郵件顯示名稱,電子郵件 2 地址,電子郵件 2 類型,電子郵件 2 顯示名稱,電子郵件 3 地址,電子郵件 3 類型,電子郵件 3 顯示名稱,網頁,網際網路空閒-忙碌中,語言,辦公室,優先順序,縮寫,關鍵字,類別";
const handler = [
    {
        category: "所本部",
        open: () => contactTreeNext("CN=3030100,OU=3030100,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-1")
    },
    {
        category: "民政課",
        open: () => contactTreeNext("CN=3030200,OU=3030200,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-2")
    },
    {
        category: "會計室",
        open: () => contactTreeNext("CN=3030400,OU=3030400,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-3")
    },
    {
        category: "社會人文課",
        open: () => contactTreeNext("CN=3030500,OU=3030500,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-4")
    },
    {
        category: "經建課",
        open: () => contactTreeNext("CN=3030600,OU=3030600,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-5")
    },
    {
        category: "工務課",
        open: () => contactTreeNext("CN=3030700,OU=3030700,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-6")
    },
    {
        category: "秘書室",
        open: () => contactTreeNext("CN=3031100,OU=3031100,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-7")
    },
    {
        category: "人事室",
        open: () => contactTreeNext("CN=3031200,OU=3031200,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-8")
    },
    {
        category: "政風室",
        open: () => contactTreeNext("CN=3031400,OU=3031400,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-9")
    },
    {
        category: "役政災防課",
        open: () => contactTreeNext("CN=3031700,OU=3031700,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3-10")
    }
];

async function openRoot() {
    contactTreeNext("CN=gDistrictOffice,ou=grpofcontact,ou=contact_group,ou=tpc,dc=ad,dc=ntpc,dc=gov,dc=tw", "-3");
    await timeout(1000);
    contactTreeNext("CN=3030000,OU=3030000,OU=3000000,OU=0000000,OU=TPC,DC=AD,DC=NTPC,DC=GOV,DC=TW", "-3-3");
    await timeout(2000);
}

async function getContact() {
    let ret = [];
    for (let i = 0; i < handler.length; ++i) {
        let current = handler[i];
        current.open();
        await timeout(2000);
        ret.push({
            category: current.category,
            contact: queryContact()
        });
    }
    return ret;
}

openRoot().then(() => getContact()).then(contact => {
    let result = header;
    for (let i = 0; i < contact.length; ++i) {
        let current = contact[i];
        let category = current.category;
        let people = current.contact;
        for (let j = 0; j < people.length; ++j) {
            let data = people[j];
            result += "\r\n" + data.name + ",,,,,永和區公所," + category + "," + data.job + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,普通,," + data.mail + ",SMTP," + data.name + " (" + data.mail + "),,,,,,,,,,,普通,,," + category;
        }
    }
    let encodeUri = "data:text/csv;charset=UTF-8,%EF%BB%BF" + encodeURI(result);
    window.open(encodeUri);
});