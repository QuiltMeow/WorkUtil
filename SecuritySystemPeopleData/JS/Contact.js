function queryContact(index) {
    let ret = [];

    let left = document.getElementById("divContactTree_-3-3-" + index);
    let leftSpan = left.querySelectorAll("span");

    let element = document.getElementById("divContactCont");
    let node = element.querySelectorAll("table.staff");
    for (let i = 0; i < node.length; ++i) {
        let person = node[i].querySelectorAll("td");
        ret.push({
            name: person[0].innerText,
            job: person[1].innerText,
            account: person[2].innerText,
            mail: person[3].innerText.trim().replace(",", "."),
            extension: leftSpan[i].innerText.split("-")[1].split("）")[0]
        });
    }
    return ret;
}

function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const header = "姓名,單位,職稱,公務帳號,電子郵件,電話,分機";
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
            contact: queryContact(i + 1)
        });
    }
    return ret;
}

async function fixPhone(data) {
    let node = document.getElementById("divContactTree_-3-3-2");
    let link = node.querySelectorAll("a");
    for (let i = 0; i < link.length; ++i) {
        link[i].onclick();
        await timeout(2000);
        let element = document.getElementById("divContactCont");
        let person = element.querySelector("table.staff");
        let item = person.querySelectorAll("tr")[7].querySelector("td").innerText;
        data[1].contact[i].phone = item;
    }

    for (let i = 0; i < data.length; ++i) {
        let contact = data[i].contact;
        for (let j = 0; j < contact.length; ++j) {
            if (contact[j].phone === undefined) {
                contact[j].phone = "(02)29282828";
            }
        }
    }
    return data;
}

openRoot().then(() => getContact()).then(data => fixPhone(data)).then(contact => {
    let result = header;
    for (let i = 0; i < contact.length; ++i) {
        let current = contact[i];
        let category = current.category;
        let people = current.contact;
        for (let j = 0; j < people.length; ++j) {
            let data = people[j];
            result += "\r\n" + data.name + "," + category + "," + data.job + "," + data.account + "," + data.mail + "," + data.phone + "," + data.extension;
        }
    }
    let encodeUri = "data:text/csv;charset=UTF-8,%EF%BB%BF" + encodeURI(result);
    window.open(encodeUri);
});