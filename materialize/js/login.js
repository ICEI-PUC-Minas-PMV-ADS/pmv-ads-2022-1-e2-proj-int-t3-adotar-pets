const button = document.getElementById('btn-entrar')
button.addEventListener('click', async (e)=>{
  e.preventDefault();

  const email = document.getElementById('email').value;
  const password = document.getElementById('senha').value;

  await signInUser({email, password});
});

async function signInUser(body) {
  const apiUrl = 'https://adoptapi.azurewebsites.net/api/auth/login';
  const settings = {
    method: 'POST',
    headers: {
      'Content-type': 'application/json'
    },
    body: JSON.stringify(body),
  };
  try {
    const response = await fetch(apiUrl, settings);
    if (!response.ok) {
      throw response;
    }
    const data = await response.json();
    localStorage.setItem('token', data.token);
    location.href = 'logado.html';
  } catch (err) {
    const error = await err.json();
    alert("Dados incorretos.");
  }
}
