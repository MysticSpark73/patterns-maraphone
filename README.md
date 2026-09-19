# Patterns Maraphone

## Goal

This project was created as an educational exercise with the main goal to achieve the better, more profound understanding of the most popular patterns not by reading about them or watching YouTube videos, but by practical implementation and real hands-on experience. By design every pattern was implemented in isolated environment as a aseparate sub-program. I tried to keep those examples concise, simple, fun and game-related if possible.

## Description
Why is it called maraphone? The idea was to dedicate several hours of my free-time each weekend to doing a little research and implementing a simple example that shows how this pattern works and what problem it solves. Can't say I strictly stuck to this plan as some patterns have much more complex implementations than the others and I did made some pauses, but at least the idea was that XD

Sometimes I struggled to come up with an inspiring example for a pattern, so I just borrowed implementation frome one of the resources I used to research. I understand that some implementations might not be best at examplifying the use of the pattern, but this was my learning journey it was meant to help me learn and explore ideas and solutions behind the patterns, not to do everything perfect.

`Program` is the main class wich runs the demonstrations. All patterns are categorized and placed inside their respective classes `Creational`, `Structural` and `Behavioral`.

Each pattern has it's own main class that is derived from `IProgram` interface that has one method: `void Run(params object[]? args)`; Use this methos if you want to launch the pattern demonstration.

Below you can read a brief description of every pattern I've implemented that would help you to grasp the basic idea behind it's implementation.
## Creational Patterns

### 🏭 Factory
A range of generic and specific factories that each produce it's own type of weapon.

✒️**Note: `CreateAdapterMethod()` is a workaround that makes possible variable input values for different objects of the same type. It is easily avidable by giving up on abstraction and not using abstract classes to create hierarchy of factories. This approach confines `Create()` method to it's original signature in the abstract class. I'd rather not use abstract classes at all and created a few specialized factories for each set of arguments instead.** 
### 🏭 Abstract Factory
An flexible factory that produces a set of furniture (chair, couch and table) based on the preferred style (art deco, modern, victorian).
### 🏗️ Builder
Builder class that could build any type of car out of different car parts such as engine, transmissin, seats, turbo, etc. This implementation also features a set of directors that have the common build steps for desired type of car consealed, exposing only necessary parts so, for example `SportsCarsDirector` only requires a `CarEngine` to build a sports car.
### 🤖 Prototype
This prototype example is built on the idea of cells division. It features a simple simulation of a cells lifecycle. The main idea revolvs around the `Cell` that has the method `Clone()`. `Cell` consist of various types of `Organelle` wich also implement the same `ICloneable<T>` interface. `Organelle` can take form of either `Mitochondria` that stores the energy level of a cell, `Nucleus` that stores `DNA` or `Ribosome` wich does nothing in this implementation.

The `SimulateCellsLifeCycle()` method runs a loop that triggers each cells `UpdateState()` method wich also triggers the same method on each of it's `Organelle`. `Mitochondria` produces energy when it's `UpdateState()` is triggered. When the combined energy level of all `Mitochondria` inside a `Cell` reaches certain level, it invokes `RequestDivision` action that is caught by `PrototypeMain` and places the clone of that `Cell' into `_bufferCells` so that newly created cells can be added to the simulation loop on the next iteration.

While cloning, each `Organelle` has it's own behavior. For example, `Mitochondria` looses half of it's `_energyLevel` and `DNA` inside the `Nucleus` can `TryMutate`.
### 1️⃣ Singletone
Lazy initializable, thread-safe version of classic Singletone. Represents a simple database that can store, add and spend currency.
## Structural Patterns

### 🔌 Adapter
Adapter between 'legacy database' represented by `ChemicalDataBank` class and new `RichCompound`. Legacy system uses string values to determine compounds and their properties whilst new system creates Compounds as objects.
### 🌉 Bridge
Bridge allows to separate vehicles from makes and extend each branch separately. Each `Vehicle` has a nested field of it's `Make`. For the sake of learning Makes have different functions embeded in them like `EnableCruiseControl(bool value)` or `EnableSportMode(bool value)`. Vehicles implement abstract `IsAllowedToDrive(DrivingLicenseType license)` method that changes what vehicles are allowed to drive by the current `DrivingLicenseType`.
### 📦 Composite
Composite has a very simple implementation that revolves around `IPriceable` interface with `float GetPrice()` method. `Item` has it's own price. Items can be placed inside the `Package` where the price of the package is equal to the sum of the prices of `Items` within it. Packages can also be placed inside other packages. To determine the final price algorithm recursively calls `float GetPrice()` on each node.
### 🪆 Decorator
`BorrowableDecorator` adds a new layer of functionality to the `MediaItem` that lets users to borrow such an item. Basic `MediaItem` can only be displayed.
### 🏛️ Facade
`ECommerceFacade` obscures the logic of the `BillingService`, `DeliveryService`, `OrderService` and `ItemsDatabase` behind a simplified interface.

✒️ **Note: In reality Facade should work either with external API or complex legacy subsystem. For the lack of either I used simple "old database" approach"**
### 🪶 Flyweight
Flyweight pattern is represented here in the form of `BulletFlyweightData` inside `BulletsFlyweightDataFactory`. `BulletFlyweightData` holds common features of different bullet types (damage, speed, sprite path, dmage type) and is stored inside `BulletsFlyweightDataFactory`. When `Bullet` is created it receives the reference to the respective data and can use it to calculate movement or damage, but values never changed or duplicated. Each bullet also has it's own properties like position, rotation and current velocity.

`FlyweightMain` creates a pool of bullets for each bullet type and then simulates firing them at a wall.
### 🗄️ Proxy
`ProxyPaymentProcessor` only passes the transaction to the `BankPaymentProcessor` after the transaction passed all `IPaymentOperationValidator` steps for the respective `PaymentMethod`.
## Behavioral Patterns

### 🔗 Chain of Responsibility
Chain of responsibility utilizes the `IHandler` interface with methods `bool Handle(SaveData saveData)` and `IHandler SetNext(IHandler handler)` to create a sequence of handlers to launch the game.
### 💾 Command
`CommandMain` crates a `House`, adds rooms to it (`RoomBase`) and fills rooms with `DeviceBase` devices.  Then commands are creatwd and added to those devices by `AddCommand(ICommand command)` method and executed. Upon execution commands are added to the `CommandLogger`.
### 🔁 Iterator
`ItemCollection` extends `IEnumerable<T>` and represents a custom collection of items and supports `FrontToBackIterator`, `BackToFrontIterator` and `FromToStepIterator` iterators inherited from `IEnumerable<T>` wich implement basic ways to sift through a collection.

✒️ **Note: technically there is no need to implement the iterator pattern in C# since we have `IEnumerable` and interface and LINQ unless you need very specific kind of iterator or you're implementing a custom collection.**
### 🚦 Mediator
`FlightControlMediator` manages Cargos (`Plane`, `PrivatePlane` and `Helicopter`) and orchestrates their landings. `CargoBase` recieves reference to the `FlightControlMediator` in constructor and requests landing immediately. `FlightControlMediator` then calls `public TakeoffLine? GetAvailableLine(LineType type)` method of the `Airport` and returns a `LandingRequestResponse` to the cargo. If there is available line, cargo then lands. If no, it is delayed and put into the `_landingQueue`.
### 📸 Memento
Memento pattern is represented by a checkers game. The game is played on a `Board` and is observed by `BoardCaretaker`. Board's `BoardMemento Setup()` and `public bool TryMakeMove(Vector2Int from, Vector2Int to, out BoardMemento? snapshot)` return `BoardMemento` snapshots of the current game states that are pushed to the `_stateLog` of the `BoardCaretaker` so every move is recorded and can be undone.
### 🔬 Observer
Observer is based on YouTube videos. `PublisherBase` represents a channel. Subscribers can be added or removed by using it's `void AddSubscriber(ISubscriber subscriber)` and `void RemoveSubscriber(ISubscriber subscriber)` methods. When new video is released `void Notify(string title)` is called for each subscriber of that channel.
### 🔭 Event Bus
Event Bus is a more elaborate form of the Observer pattern. This implementation features the achievement system of the hypothetical game and is based on flexible generic EventBus foundation. 

`EventBus` itself is a static class and has three methods: `void Subscribe<T>(Action<T> callback)`, `void Unsubscribe<T>(Action<T> callback)` and `void Invoke<T>(T @event)`. `EventBus` manages it's own subscribers manualy and stores them in `Dictionary<Type, List<Delegate>> _subscribers`. Each game event is represented by it's own class with it's own logic. for example `LevelCompleteEvent` contains the level rewards that can be used by it's subscribers.

Achievements are inherited from the `AchievementBase` class and contain their own conditions and data. For example `EarnMoneyAchievement` has both `TargetCoins` and `_cachedCoins` fields so every time player recieves a reward achievement can add that reward to `cachedCoins` and check if the condition is met internally. Each achievement has `Func<bool> _condition` that determines whether this achievement is unlocked. This condition is overwritten in derived achievement classes. Achievements subscribe to the necessary events in the constructor.

`EventBusMain` simulates a simplified game loop. It creates all the necessary systems, then subscribes to the global events and creates levels. When all setup is done it runs `void SimulateGameLoop()` wich runs through every level and kills all enemies until all levels are completed.
### 🧮 State
State was based on the idea of recreating the process of casting spells in World of Warcraft. I wanted to recreate this process in a simplified way while maintaining the core idea behind it. Those are the rules I followed while implementing this feature:

* Each character has access to some set of abilities.
* Abilities can be in one of the following states: ready, on cooldown, casting, channeling.
* Abilities can be cancelled by the caster or interrupted by an enemy (outcomes may vary)
* When ability is cast it goes on the cooldown and becomes unavailable until colldown time is up.
* When any ability is cast (except those abilities that ignore global cooldown), all abilities go on a short global cooldown that prevents character from casting any other abilities.
* Some abilities may have instant cast speed.
* Some abilities may ignore global cooldown.
* Some spells may apply effects on enemy. Those effects cooldowns may be reset by recasting the same ability.
* Some spells need to be channeled wich means first they have to be cast and then channeled until channel duration or until character cancelles the spell.

`CharacterBase` represents the character. Character has a set of parameters such as health, mana, and active effects. Character also has `ClassBase` that plays a role of the abilities container. When Character wants to cast ability it requests the needed ability by calling `AbilityBase? GetSpell(string name)` from it's class.

`AbilityData` is a flyweight data of an ability that is created and stored in `AbilityDatabase`. It consists of the name, cast time, channel duration, ability duration, cooldown, `IsAffectedByGlobalCooldown` flag and a required class.

`AbilityBase` is the base class for the ability. It has a reference to the `AbilityData` and contains all logic related to ability. `AbilityBase` acts as state machine for the `AbilityCastStateBase`. It also has access to both internal `LocalCooldownManager` and a `GlobalCooldownManager` that it recieves from the character.

There are several global interfaces implemented by both abilities and states: `ICastable`, `ICancelable`, `IInterruptable` and `IChannelable`. `AbilityCastStateBase` implements all of those interfaces while any ability only required to implement `ICastable`.

Abilities default to the `AbilityReadyState` when created. While ability is in the `AbilityReadyState` it can only be cast (all other public methods //do nothing) if it's not on a local cooldown and is either ignores global cooldown or not on a global cooldown. If all of the requirements are met, ability then transitions to the `AbilityCastingState`.

While ability is in the `AbilityCastingState` it can be cancelled or interrupted. If casting time is instand or of casting Task has finished ability transfers either to the `AbilityChannelingState` or `AbilityReadyState` depending on whether it can be channeled or not. If ability goes to the `AbilityReadyState` from the `AbilityCastingState` or `AbilityChannelingState` it also goes on a cooldown.

✒️ **Note: State pattern could've been made much much simpler and I've recieved a lot of constructive criticism about my particular implementation. If you need simpler, clearer and easier to understand variation of a state, please check any of the sources instead.**

✒️ **Note: This implementation of abilities heavily relies on Tasks and asynchronous methods. I used `TasksExtension` class to be able  to fire-and-forget tasks and to be able to run some of them synchronously. This class is very important if you want to dive deeper into how states and abilities in this example are implemented.**
### 🆎 Strategy
Strategy is based on the firearms and different shooting modes. Each `Firearm` can `void Shoot()`, `void Reload()` and `void SwitchShootingMode()`. Some firearms have access to several shooting modes while others are constricted to have only one. For example `AssaultRifle` can utilize `SingleShotStrategy`, `BurstShotStrategy` or `AutomaticShotStrategy` and can cycle through different modes mid-shooting. 

Each strategy implements the `IShootingStrategy` and has `void Shoot(FirearmData data, ref int bullets)` method
### 📋 Template Method
`WindowBase` represents a template method. It has `void Show()` and `void Hide()` public methods that define the order in wich the other internal methods are called. Those methods can be overwritten by the derived classes to add new logic at any step. For example, `AnimatedWindow` plays animation when shown or hidden and all other windows that derive from the `AnimatedWindow` can add their own logic on top of that.
### 🚪 Visitor
Visitor is based on the idea of different damage types interaction with creature types. Creatures are represented by the `Entity` class and implement the `IVisitable` interface. `IVisitable` has one method: `void Accept(IVisitor visitor)`.

`SpellBook` is a database of `Spell` that can be cast on entities. Each spell has `IVisitor _mainEffectVisitor` and `protected IVisitor? _secondaryEffectVisitor`. Each visitor represents a different type of effect, like `PhysicalDamageVisitor`, `FireDamageVisitor` or `StunVisitor`. So, for example, `ShieldSlam` spell can have both `PhysicalDamageVisitor` that deals physical damage and `StunVisitor` that applies stun to the target.

Based on the type of effect and the visited entity, visitor may apply different modificators to the effects. For example `FireDamageVisitor` deals no damage when visiting `FireElemental` since fire elementals are obciously immune to fire. Or `NecroticDamageVisitor` applies healing instead of damage when visiting `Undead` creatures.
## Thanks

Special thanks to peaople who supported me on my journey.

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