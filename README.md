# Patterns Marathon

## Goal

This project was created as an educational exercise with the main goal of achieving a better, more profound understanding of the most popular patterns not by reading about them or watching YouTube videos, but by practical implementation and real hands-on experience. By design, every pattern was implemented in an isolated environment as a separate subprogram. I tried to keep those examples concise, simple, fun and game-related if possible.

## Description
Why is it called marathon? The idea was to dedicate several hours of my free time each weekend to doing a little research and implementing a simple example that shows how this pattern works and what problem it solves. Can't say I strictly stuck to this plan as some patterns have much more complex implementations than the others and I did take some breaks, but at least the idea was that XD

Sometimes I struggled to come up with an inspiring example for a pattern, so I just borrowed implementation from one of the resources I used to research. I understand that some implementations might not be best at exemplifying the use of the pattern, but this was my learning journey, it was meant to help me learn and explore ideas and solutions behind the patterns, not to do everything perfectly.

`Program` is the main class which runs the demonstrations. All patterns are categorized and placed inside their respective classes `Creational`, `Structural` and `Behavioral`.

Each pattern has its own main class that implements the `IProgram` interface which defines one method: `Run(params object[]? args)`. Use this method if you want to launch the pattern demonstration.

Below you can read a brief description of every pattern I've implemented which should help you to grasp the basic idea behind its implementation.
## Creational Patterns

### 🏭 Factory
A range of generic and specific factories that each produce its own type of weapon.

✒️**Note: `CreateAdapterMethod()` is a workaround that makes possible variable input values for different objects of the same type. Creation of this method can be avoided by giving up on abstraction in the class hierarchy and not tying all factories to the same base abstract class.** 
### 🏭 Abstract Factory
A flexible factory that produces a set of furniture (chair, couch and table) based on the preferred style (Art Deco, Modern, Victorian).
### 🏗️ Builder
Builder class that can build any type of car out of different car parts such as engine, transmission, seats, turbo, etc. This implementation also features a set of directors that have the common build steps for the desired type of car concealed, exposing only the necessary parts so, for example `SportsCarsDirector` only requires a `CarEngine` to build a sports car.
### 🤖 Prototype
This prototype example is built on the idea of cell division. It features a simple simulation of a cell's lifecycle. The main idea revolves around the `Cell` that has the method `Clone()`. `Cell` consists of various types of `Organelle` which also implement the same `ICloneable<T>` interface. `Organelle` can take the form of either `Mitochondria` that stores the energy level of a cell, `Nucleus` that stores `DNA` or `Ribosome` which does nothing in this implementation.

The `SimulateCellsLifeCycle()` method runs a loop that triggers each cell's `UpdateState()` method which also triggers the same method on each of its `Organelle`. `Mitochondria` produces energy when its `UpdateState()` is triggered. When the combined energy level of all `Mitochondria` inside a `Cell` reaches a certain level, it invokes `RequestDivision` action that is caught by `PrototypeMain` and places the clone of that `Cell` into `_bufferCells` so that newly created cells can be added to the simulation loop on the next iteration.

While cloning, each `Organelle` has its own behavior. For example, `Mitochondria` loses half of its `_energyLevel` and `DNA` inside the `Nucleus` can `TryMutate`.
### 1️⃣ Singleton
A lazily initialized, thread-safe version of the classic Singleton. Represents a simple database that can store, add and spend currency implemented by the `Database` class.
## Structural Patterns

### 🔌 Adapter
Adapter between the 'legacy database' represented by the `ChemicalDataBank` class and the new `RichCompound`. The legacy system uses string values to determine compounds and their properties whilst the new system creates Compounds as objects.
### 🌉 Bridge
Bridge allows to separate vehicles from makes and extend each branch separately. Each `Vehicle` has a field containing its `Make`. For the sake of learning, makes have different functions embedded in them like `EnableCruiseControl(bool value)` or `EnableSportMode(bool value)`. Vehicles implement the abstract `IsAllowedToDrive(DrivingLicenseType license)` method that changes what vehicles are allowed to drive with the current `DrivingLicenseType`.
### 📦 Composite
Composite has a very simple implementation that revolves around the `IPriceable` interface with `GetPrice()` method. `Item` has its own price. Items can be placed inside the `Package` where the price of the package is equal to the sum of the prices of `Items` within it. Packages can also be placed inside other packages. To determine the final price algorithm recursively calls `float GetPrice()` on each node.
### 🪆 Decorator
`BorrowableDecorator` adds a new layer of functionality to the `MediaItem` that lets users borrow such an item. Basic `MediaItem` can only be displayed.
### 🏛️ Facade
`ECommerceFacade` obscures the logic of the `BillingService`, `DeliveryService`, `OrderService` and `ItemsDatabase` behind a simplified interface.

✒️ **Note: In reality Facade should work either with an external API or a complex legacy subsystem. In the absence of either I used a simple "old database" approach**
### 🪶 Flyweight
Flyweight pattern is represented here in the form of `BulletFlyweightData` inside `BulletsFlyweightDataFactory`. `BulletFlyweightData` holds common features of different bullet types (damage, speed, sprite path, damage type) and is stored inside `BulletsFlyweightDataFactory`. When `Bullet` is created it receives the reference to the respective data and can use it to calculate movement or damage, but the values never change or get duplicated. Each bullet also has its own properties like position, rotation and current velocity.

`FlyweightMain` creates a pool of bullets for each bullet type and then simulates firing them at a wall.
### 🗄️ Proxy
`ProxyPaymentProcessor` only passes the transaction to the `BankPaymentProcessor` after the transaction passed all `IPaymentOperationValidator` steps for the respective `PaymentMethod`.
## Behavioral Patterns

### 🔗 Chain of Responsibility
Chain of Responsibility utilizes the `IHandler` interface with methods `Handle(SaveData saveData)` and `SetNext(IHandler handler)` to create a sequence of handlers to launch the game.
### 💾 Command
`CommandMain` creates a `House`, adds rooms to it (`RoomBase`) and fills rooms with `DeviceBase` devices. Then commands are created and added to those devices by `AddCommand(ICommand command)` method and executed in the `ExecuteCommands()` method. Upon execution commands are added to the `CommandLogger`.
### 🔁 Iterator
`ItemCollection` extends `IEnumerable<T>` and represents a custom collection of items and supports `FrontToBackIterator`, `BackToFrontIterator` and `FromToStepIterator`. Iterators implement the `IEnumerable<T>` interface and realize basic ways to iterate through a collection.

✒️ **Note: technically there is no need to implement the iterator pattern in C# since we have the `IEnumerable` interface and LINQ unless you need very specific kind of iterator or you're implementing a custom collection.**
### 🚦 Mediator
`FlightControlMediator` manages Cargos (`Plane`, `PrivatePlane` and `Helicopter`) and orchestrates their landings. `CargoBase` receives reference to the `FlightControlMediator` in the constructor and requests landing immediately. `FlightControlMediator` then calls `GetAvailableLine(LineType type)` method of the `Airport` and returns a `LandingRequestResponse` to the cargo. If a line is available, cargo then lands. If not, its landing is delayed and the cargo is put into the `_landingQueue`.
### 📸 Memento
Memento pattern is represented by a checkers game. The game is played on a `Board` and is observed by `BoardCaretaker`. The board's `Setup()` and `TryMakeMove(Vector2Int from, Vector2Int to, out BoardMemento? snapshot)` return `BoardMemento` snapshots of the current game state that are pushed to the `_stateLog` of the `BoardCaretaker` so every move is recorded and can be undone.
### 🔬 Observer
Observer is based on YouTube videos. `PublisherBase` represents a channel. Subscribers can be added or removed by using its `AddSubscriber(ISubscriber subscriber)` and `RemoveSubscriber(ISubscriber subscriber)` methods. When a new video is released, `Notify(string title)` is called for each subscriber of that channel.
### 🔭 Event Bus
Event Bus is a more elaborate form of the Observer pattern. This implementation features the achievement system of the hypothetical game and is based on a flexible generic EventBus foundation. 

`EventBus` itself is a static class and has three methods: `Subscribe<T>(Action<T> callback)`, `Unsubscribe<T>(Action<T> callback)` and `Invoke<T>(T @event)`. `EventBus` manages its own subscribers manually and stores them in `Dictionary<Type, List<Delegate>> _subscribers`. Each game event is represented by its own class with its own logic. For example `LevelCompleteEvent` contains the level rewards that can be used by its subscribers.

Achievements are inherited from the `AchievementBase` class and contain their own conditions and data. For example `EarnMoneyAchievement` has both `TargetCoins` and `_cachedCoins` fields so every time the player receives a reward, the achievement can add that reward to `_cachedCoins` and check if the condition is met internally. Each achievement has `Func<bool> _condition` that determines whether this achievement is unlocked. This condition is assigned in derived achievement classes. Achievements subscribe to the necessary events in the constructor.

`EventBusMain` simulates a simplified game loop. It creates all the necessary systems, then subscribes to the global events and creates levels. When all setup is done it runs `SimulateGameLoop()` which runs through every level and kills all enemies until all levels are completed.
### 🧮 State
State was based on the idea of recreating the process of casting spells in World of Warcraft. I wanted to recreate this process in a simplified way while maintaining the core idea behind it. These are the rules I followed while implementing this feature:

* Each character has access to a set of abilities.
* Abilities can be in one of the following states: ready, on cooldown, casting, channeling.
* Abilities can be cancelled by the caster or interrupted by an enemy (outcomes may vary).
* When an ability is cast, it goes on cooldown and becomes unavailable until cooldown time is up.
* When any ability is cast (except those abilities that ignore global cooldown), all abilities go on a short global cooldown that prevents the character from casting any other abilities.
* Some abilities may have instant cast speed.
* Some abilities may ignore global cooldown.
* Some spells may apply effects on an enemy. Those effects' cooldowns may be reset by recasting the same ability.
* Some spells need to be channeled which means first they have to be cast and then channeled until channel duration or until the character cancels the spell.

`CharacterBase` represents the character. The character has a set of parameters such as health, mana, and active effects. The character also has `ClassBase` that plays a role of the abilities container. When the character wants to cast an ability it requests the needed ability by calling `GetSpell(string name)` from its class.

`AbilityData` is flyweight data of an ability that is created and stored in `AbilityDatabase`. It consists of the name, cast time, channel duration, ability duration, cooldown, `IsAffectedByGlobalCooldown` flag and a required class.

`AbilityBase` is the base class for abilities. It has a reference to the `AbilityData` and contains all logic related to ability. `AbilityBase` acts as a state machine for the `AbilityCastStateBase`. It also has access to both internal `LocalCooldownManager` and a `GlobalCooldownManager` that it receives from the character.

There are several global interfaces implemented by both abilities and states: `ICastable`, `ICancelable`, `IInterruptable` and `IChannelable`. `AbilityCastStateBase` implements all of those interfaces while any ability (class derived from `AbilityBase`) is only required to implement `ICastable`.

Abilities default to the `AbilityReadyState` when created. While an ability is in the `AbilityReadyState` it can only be cast (all other public methods `//do nothing`) if it's not on a local cooldown and either not on global cooldown or ignores global cooldown. If all of the requirements are met, the ability then transitions to the `AbilityCastingState`.

While an ability is in the `AbilityCastingState` it can be cancelled or interrupted. If the casting time is instant or the casting Task has finished, the ability transitions either to the `AbilityChannelingState` or `AbilityReadyState` depending on whether it can be channeled or not. If the ability goes to the `AbilityReadyState` from the `AbilityCastingState` or `AbilityChannelingState` it also goes on a cooldown.

✒️ **Note: State pattern could've been made much much simpler and I've received a lot of constructive criticism about my particular implementation. If you need simpler, clearer and easier to understand variation of the state, please check any of the sources instead.**

✒️ **Note: This implementation of abilities heavily relies on Tasks and asynchronous methods. I used the `TasksExtension` class to be able to fire-and-forget tasks and to be able to run some of them synchronously. This class is very important if you want to dive deeper into how states and abilities in this example are implemented.**
### 🆎 Strategy
Strategy is based on the firearms and different shooting modes. Each `Firearm` can `Shoot()`, `Reload()` and `SwitchShootingMode()`. Some firearms have access to several shooting modes while others are restricted to have only one. For example `AssaultRifle` can utilize `SingleShotStrategy`, `BurstShotStrategy` or `AutomaticShotStrategy` and can cycle through different modes mid-shooting. 

Each strategy implements the `IShootingStrategy` interface and has a `Shoot(FirearmData data, ref int bullets)` method.
### 📋 Template Method
`WindowBase` implements the template method pattern. It has `Show()` and `Hide()` public methods that define the order in which the other internal methods are called. Those methods can be overridden by the derived classes to add new logic at any step. For example, `AnimatedWindow` plays animation when shown or hidden and all other windows that derive from the `AnimatedWindow` can add their own logic on top of that.
### 🚪 Visitor
Visitor is based on the idea of how different damage types interact with creature types. Creatures are represented by the `Entity` class and implement the `IVisitable` interface. `IVisitable` has one method: `Accept(IVisitor visitor)`.

`SpellBook` is a database of `Spell` objects that can be cast on entities. Each spell has `IVisitor _mainEffectVisitor` and `protected IVisitor? _secondaryEffectVisitor`. Each visitor represents a different type of effect, like `PhysicalDamageVisitor`, `FireDamageVisitor` or `StunVisitor`. So, for example, the `ShieldSlam` spell can have both `PhysicalDamageVisitor` that deals physical damage and `StunVisitor` that applies stun to the target.

Based on the type of effect and the visited entity, visitor may apply different modifiers to the effects. For example `FireDamageVisitor` deals no damage when visiting `FireElemental` since fire elementals are obviously immune to fire. Or `NecroticDamageVisitor` applies healing instead of damage when visiting `Undead` creatures.
## Thanks

Special thanks to people who supported me on this journey.

Thanks to the people who dedicated their time to give me their feedback via code-review. You really helped me to understand all the nuances that come with the implementation of the patterns and catch issues in my code.

[Aspexis](https://github.com/Aspexis)

[GoldunRoman](https://github.com/GoldunRoman)

[Darrior](https://github.com/Grodas-Oleg)

[Valentyn](https://github.com/nickeltin1)

[Alex](https://github.com/RollsRoyce13)

Demidov Roman

## Sources

These are the main sources of information I used in my research.

[Refactoring Guru: Catalog of Design Patterns](https://refactoring.guru/design-patterns/catalog)

[Dofactory: C# Design Patterns](https://www.dofactory.com/net/design-patterns)

### YouTube

[Raw Coding: c# design patterns](https://youtube.com/playlist?list=PLOeFnOV9YBa4ary9fvCULLn7ohNKR6Ees&si=OtukyLeV6q9JZfYN)

[Geekific: Design Patterns](https://youtube.com/playlist?list=PLlsmxlJgn1HJpa28yHzkBmUY-Ty71ZUGc&si=cSUMkk-qOx3bkfZI)

[Zoran on C#: Design Patterns in C# .NET](https://youtube.com/playlist?list=PLSDYwLgFqaX67uAmvdKQVCtiQ0-Ji2DXP&si=SZMfTs70vcJWJuQn)

[Coding Tutorials: Design Patterns](https://youtube.com/playlist?list=PLQB-TSatJvw67iRU5XmdDC3roaeGA57KC&si=5xJyFakhMip8wD-B)

and many others...