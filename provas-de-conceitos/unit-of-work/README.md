# Unit of Work (Prova de Conceito)

Projeto de uma prova de conceito do [Unit Of Work][ref-1], um pattern que possibilita o compartilhamento de um mesmo contexto em comum do [Entity Framework][tec-3] em diversos repositórios.

## Autores

* **Tiago Felipe dos Santos** - [Github](https://github.com/taigosantos) - [Linkedin](https://www.linkedin.com/in/tiago-santos-36b25341/) - [E-mail](mailto:taigobrasil@gmail.com)

## Tecnologias de Desenvolvimento

[tec-1]: https://github.com/dotnet
[tec-2]: https://github.com/dotnet/csharplang
[tec-3]: https://github.com/aspnet/EntityFramework6
[tec-4]: https://simpleinjector.org

* [.NET Framework 4.6.x][tec-1]
* [.NET Framework C# 7.x][tec-2]
* [Entity Framework 6.x][tec-3]
* [Simple Injector 4.x][tec-4]


## Referências de Estudos

[ref-1]: https://martinfowler.com/eaaCatalog/unitOfWork.html
[ref-2]: https://www.youtube.com/watch?v=4nqL31Qti_M
[ref-3]: https://www.youtube.com/watch?v=SRIiWg_yY4I&t=973s
[ref-4]: https://www.youtube.com/watch?v=Da_bGoUlITQ
[ref-5]: https://www.youtube.com/watch?v=08mLfQHlbik
[ref-6]: https://github.com/DenisBiondic/ScopedUnitOfWork
[ref-7]: http://mehdi.me/ambient-dbcontext-in-ef6
[ref-8]: https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=100

* [Unit Of Work][ref-1] - Descrição do Pattern.
* [Unit Of Work - PARTE 1][ref-2] - Vídeo tutorial sobre Unit of Work (Parte 1).
* [Unit Of Work - PARTE 2][ref-3] - Vídeo tutorial sobre Unit of Work (Parte 2).
* [IoC e DI][ref-4] - Vídeo tutorial sobre injeção de dependência e inversão de controle.
* [SOLID - Interface Segregation Principle][ref-5] - Vídeo tutorial sobre o princípio de segregação de interface.
* [ScopedUnitOfWork][ref-6] - Repositório contendo um projeto completo sobre Scoped Context.
* [Managing DbContext the right way][ref-7] - Artigo descrevendo o modo correto de utilizar um contexto no Entity Framework
* [Abstract Factories are a code smell][ref-8] - Artigo explicando que Abstract Factories são "code smell".


## Considerações

* O artigo [Abstract Factories are a code smell][ref-1] diz que a utilização de abstract factories não é uma boa prática de programação, sendo assim foi substituída a classe `IUnitOfWorkFactory` pela dependência `Func<IUnitofWorkContextAware>`.
* Ao invés de _Ninject_ utilizada no tutorial [Unit Of Work - PARTE 1][ref-2] e [Unit Of Work - PARTE 2][ref-3], foi usada a tecnologia [Simple Injector][tec-4].
