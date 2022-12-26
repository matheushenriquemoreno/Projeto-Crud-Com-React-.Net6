## Projeto em Desenvolvimento


<p> 
<h2> O que foi implementado: </h2>

<h3> No back end: </h3>
Foi implementado a autentificarão via token jwt utilizando a biblioteca Identity da própria Microsoft, para essa implementação foi criado uma api que encapsula todos essas responsabilidades e as outras apis que seria a de aluno somente se preocupar com o porquê da sua existência.
Em quesito de banco de dados utilizei a abordagem Code-First onde consiste em fazer primeiro os relacionamento dos seu objetos na camada de Programação orientada a objetos, e logo após fazer as entidades serem criadas no banco de dados pela ORM Entity Framework.
<h3> No fron-end: </h3>
Foi utilizado a biblioteca React poderosíssima que traz varias funcionalidade e liberdades que se espera em um projeto. Foi aplicado o conceito de consonantização e boas praticas de separação de pasta, além de um middleware que intercepta cada requisição do back-end para confirmar se o token do usuário ainda esta valido, não estando valido ele e redirecionando para a pagina principal.



</p>

<hr>

## Demostrativo do sistema atualmente:

https://user-images.githubusercontent.com/69221000/209488293-a3c0188f-78ec-4b12-b2b4-6a7d81ed870f.mp4

<hr>

## Novas features a serem implementadas:

<ul>
<li> Tela de cadastro para o usuario, pois cadastro existe somente via API; </li>
<li> Paginação na tela inicial ao trazer todos os alunos; </li>
<li> Aplicar validações no front end utilizando as bibliotecas Formik e o Yup, Atualmente so existe validações no back end;  </li>
<li> e Criar tela de User, pois projeto foi pensado primeiramente somente na area de Admim.</li>
</ul>

