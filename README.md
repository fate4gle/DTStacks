
The "Digital Twinning Stacks": An open-source MQTT framework for Unity3D.
For documentation of this project please proceed to the [Wiki](https://github.com/fate4gle/DTStacks/wiki)! If questions remain, please enter an issue regarding it!

***
# Quickstart Guide

## Prerequisits 
* Unity 2018.1 (or later)
* Visual Studio 2017 (or later) with "Game development with Unity" workload
* Access to an MQTT Broker

For more information regarding setting up the development environment, please visit the [Development Environment Setup](https://github.com/fate4gle/DTStacks/wiki/Development-Environment-Setup) wiki page.


***

## Create a new project in Unity 

To create a new project, open Unity Hub, navigate to the project tab and click on the `New` button at the top right.
Choose your desired project setup and click on `Create` to instruct unity to create the new project automatically.

## Including DTStacks

You can choose to download DTStacks in multiple ways. Either by cloning the repository, download the repo as a complete .zip file or simply download the packages you desire by licking on it in the list below:

* <a id="raw-url" href="https://github.com/fate4gle/DTStacks/archive/refs/tags/V1.0.zip">Complete DTStacks</a> , including all available extensions.

_Note: This list will be extended with separate modules, once dedicated packages for specific use cases are released. (E.g. an extension for ROS, home automation, etc)._

Once downloaded, unpack the zip file and simply drag the DTStacks folder in your Unity project folder. Unity will automatically take care of importing all files accordingly. Once the import is completed, DTStacks is ready to be used.

## Create a communication pipeline
To simplify and speed up development efforts, DTStacks includes a message generator that allows a user to construct new messages, publishers, and subscribers using a simple interface. With only a couple of clicks, a new communication pipeline can be created!

To get started, click on the new tab `DTStacks`, navigate to `Create`, and click on `Message`. 

<p align="center">
  <img src="https://github.com/fate4gle/MirrorLabs_Release/blob/main/RM_Graphics/DTStack_Message.gif" />
</p>

This will open a new editor window where a new message can be configured, do this to your liking. (As a test, simply use an integer.) By default, the `message generator` will only create a new message (as a new C# class), if a dedicated publisher and/or subscriber is desired, enable the checkbox at the bottom of the editor window. These publishers and subscribers will be named after the name of your message (e.g. `<YourMessageName>Publisher`).

<p align="center">
  <img src="https://github.com/fate4gle/MirrorLabs_Release/blob/main/RM_Graphics/DTStack_MessageCreation.gif" />
</p>

By clicking on `Generate Message` the new message will be created and stored in the `DTStacks>DataType>Generic>Custom` directory. (If publisher and subscriber are enabled, these will be located under `DTStacks>UnityComponents>Generic>Publisher>Custom` and `DTStacks>UnityComponents>Generic>Subscriber>Custom`)

## Setup of Publisher and Subscriber

With a new message, publisher and subscriber, create a new game object in the hierarchy of your scene. (Right-click in your Scene hierarchy and select `Create Empty`.) Once created, click on the `Add Component` button in the inspector and search for your new publisher and add it to your script. Then repeat for the subscriber. 

With both components attached, enter the details of the broker to each and hit the play button! (If you do not have access to an mqtt broker, you can use the mosquitto test broker. Enter `test.mosquitto.org` in the address field.) Futhermore, enter a topic! (E.g. DTStacks/test) 

<p align="center">
  <img src="https://github.com/fate4gle/MirrorLabs_Release/blob/main/RM_Graphics/Unity_SubscriberConfiguration.gif" />
</p>


Once you hit play, you will see a message in the console informing you about the MQTT connection attempt. (If successful this will read `MQTT Connected` otherwise `CONNECTION FAILED`.) Now manipulate the integer of your new message at the PUBLISHER component and observe how it will be adapted in the subscriber with only a minor delay! 

_Note: If nothing changes, verify that:_
1. _You received an `MQTT Connected` notification (if nothing is in the Console, make sure the `Auto Connect` checkbox is enabled)_
2. _The topics are identical for subscriber and publisher_
3. _The publishers' `is Using Continous Update` checkbox is enabled_


