const welcome = document.querySelector(".welcome")
const currentUser = JSON.parse(sessionStorage.getItem('user'));
welcome.textContent = `welcome back ${currentUser.FName}`;

async function updateUser() {
    try {
        const Email = document.querySelector("#Email").value;
        const FirstName = document.querySelector("#FirstName").value;
        const LastName = document.querySelector("#LastName").value;
        const password = document.querySelector("#password").value;

        let currentUser = JSON.parse(sessionStorage.getItem('user'));
        if (!currentUser) {
            alert("No current user in sessionStorage");
            return;
        }

        const Id = currentUser.id;
        const data = { Id, Email, FirstName, LastName, password: password };



        console.log("PUT body:", JSON.stringify(data));

        const response = await fetch(`api/Users/${Id}`, {
            method: 'PUT',
            headers: {

                'Content-Type': 'application/json'

        },
            body: JSON.stringify(data)
    });
        if (response.status == 400) {
            const responseText = await response.text();
            if (responseText == "Password")
                throw Error("Your password is too weak.")
            throw Error("Please try again")
        }

    if (response.ok) {
        currentUser.Email = Email;
        currentUser.FirstName = FirstName;
        currentUser.LastName = LastName;
        currentUser.Password = password;
        sessionStorage.setItem('user', JSON.stringify(currentUser));
        alert("success");
    }
    else {
        const update = await response.text();
        console.error('API error:', response.status, update);
        alert("Update failed: " + response.status);
    }
}
    catch (e) {
        console.error(e);
        alert(e);
    }
}