# Unit Tests (Prova de Conceito)

Projeto de uma prova de conceito sobre [Unit Testing][ref-1], técnica utilizada em princípios de desenvolvimento do [TDD (Test Driven Development)][ref-2].

## Autores

* **Tiago Felipe dos Santos** - [Github](https://github.com/taigosantos) - [Linkedin](https://www.linkedin.com/in/tiago-santos-36b25341/) - [E-mail](mailto:taigobrasil@gmail.com)

## Tecnologias de Desenvolvimento

[tec-1]: https://msdn.microsoft.com/en-us/library/ms182486.aspx
[tec-2]: http://fluentassertions.com/
[tec-3]: http://nsubstitute.github.io/

* [MSTest][tec-1]
* [Fluent Assertions][tec-2]
* [NSubstitute ][tec-3]

## Referências de Estudos

[ref-1]: https://pt.wikipedia.org/wiki/Teste_de_unidade
[ref-2]: https://pt.wikipedia.org/wiki/Test_Driven_Development
[ref-3]: https://www.youtube.com/watch?v=fKy2NCKvzSQ&t=131s
[ref-4]: https://www.youtube.com/watch?v=2Q1JbixVdmU&t=7s
[ref-5]: https://www.youtube.com/watch?v=jX5wOLwj2sA&t=92s
[ref-6]: http://tech.trailmax.info/2014/03/how-we-do-database-integration-tests-with-entity-framework-migrations/
[ref-7]: https://lostechies.com/jimmybogard/2012/10/18/isolating-database-data-in-integration-tests/
[ref-8]: https://lostechies.com/jimmybogard/2013/06/18/strategies-for-isolating-the-database-in-tests/

* [Unit Testing][ref-1] - Artigo sobre a técnica de teste de unidade.
* [TDD (Test Driven Development)][ref-2] - Artigo sobre o princípio de desenvolvimento TDD.
* [TDD com NSubstitute, Fluent Assertions e ReSharper - PARTE 1][ref-3] - Vídeo tutorial sobre TDD (Parte 1).
* [TDD com NSubstitute, Fluent Assertions e ReSharper - PARTE 2][ref-4] - Vídeo tutorial sobre TDD (Parte 2).
* [TDD com NSubstitute, Fluent Assertions e ReSharper - PARTE 3][ref-5] - Vídeo tutorial sobre TDD (Parte 3).
* [How We Do Database Integration Tests With Entity Framework Migrations][ref-6] - Tutorial ensinando a testar a camada de repositórios testes integrados.
* [Isolating database data in integration testsPosted][ref-7] - Artigo sobre isolar um bando de dados para testes integrados.
* [Strategies for isolating the database in tests][ref-8] - Estratégias de como isolar um banco de dados para testes integrados.

## Considerações

* Artigos que fizeram eu optar pela tecnologia [NSubstitute ][tec-3]:
  * [NSubstitute vs Moq - a quick comparison](http://programmaticallyspeaking.com/nsubstitute-vs-moq-a-quick-comparison.html)
  * [C# Test Mocking Frameworks](https://helloacm.com/c-test-mocking-frameworks)
  * [Mocking: why we picked NSubstitute](http://weareadaptive.com/2014/09/30/why-nsubstitute)
  
* Artigos que fizeram eu optar pela tecnologia [Fluent Assertions][tec-2]:
  * https://dotnet.libhunt.com/project/fluentassertions/vs/shouldly?rel=cmp-cat

* Como base de código para os testes, utilizei o projeto [Unit of Work (Prova de Conceito)](../unit-of-work/README.md) que já tinha desenvolvido antes.

* Para os testes da camada de repositório, utilizei as premissas dos **Testes Integrando**, seguindo os artigos:
  * [How We Do Database Integration Tests With Entity Framework Migrations][ref-6]
  * [Isolating database data in integration testsPosted][ref-7]
  * [Strategies for isolating the database in tests][ref-8]