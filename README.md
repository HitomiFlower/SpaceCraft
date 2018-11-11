# SpaceCraft
For DOP learning

The tutorial link：
https://software.intel.com/en-us/articles/get-started-with-the-unity-entity-component-system-ecs-c-sharp-job-system-and-burst-compiler

But some code has been obesoleted.

DOP is very fast and the structure is easier than OOP.
But has some problems now.

First, create every properpty into a component without auto script generator is a waste of time.
I think it do need to produce a tool to generate entity component.

Second, there is a lot of process is proceed in the inner process. Such as IParallelFor, make it difficult to understand what happend to the data.
It also makes debugging harder than OOP. It need programmer to learn more about IL2Cpp and C++ language.

Third, the thinking of OOP can not transform to the DOP easily. 
