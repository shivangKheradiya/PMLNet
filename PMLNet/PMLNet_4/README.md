# 🔹 PMLNet_4

This guide demonstrates the integration of **C# events** and **exception handling** with **AVEVA E3D’s PML (Plant Model Language)** through **PMLNet** interoperability.
The example shows how to trigger events, handle callbacks in PML, and manage both normal and PMLNet-specific exceptions.

---

## ⚙️ **Examples**

### **1. Event Declaration**

Defines a PMLNet event handler compatible with AVEVA’s internal delegate system.

```csharp
public event PMLNetDelegate.PMLNetEventHandler MyPmlNetEvent;
```

This allows **PML** to subscribe to the event and handle callbacks when triggered.

---

### **2. Triggering the Event**

The `TriggerEvent()` method raises the event with a static argument list ( `ArrayList` ) from C# method, which are passed back to PML as an array.

```csharp
[PMLNetCallable()]
public void TriggerEvent()
{
    ArrayList args = new ArrayList();
    args.Add("My Arg 1");
    args.Add("My Arg 2");

    if (MyPmlNetEvent != null)
    {
        MyPmlNetEvent(args);
    }
}
```

**PML Usage:**
```pml
import 'PMLNet_4'
using namespace 'PMLNet_4'

!MyPMLNet = object MyPMLNet()

-- `PmlObject` object has `callback` method.
!PmlObject = object PmlObject()
!handler = !MyPMLNet.addeventhandler('MyPmlNetEvent', !PmlObject, 'callback')

-- The `callback` method from `PmlObject` is triggered while we are running the C# method.
!MyPMLNet.TriggerEvent()
```

---

### **3. Exception Handling**

This class defines two types of exceptions:

#### **a. Normal Exception**

A standard C# exception that, when thrown, will be shown as a generic C# Exception. 

```csharp
[PMLNetCallable()]
public void ThrowNormalException()
{
    throw new Exception();
}
```

**PML Usage:**
```pml
!MyPMLNet.ThrowNormalException()
```

#### **b. PMLNet Exception**

A structured exception that carries additional PMLNet-compatible context.

```csharp
[PMLNetCallable()]
public void ThrowPMLNetException()
{
    throw new PMLNetException(1000, 100, "My Exception");
}
```

The parameters `(1000, 100, "My Exception")` represent:

* **1000** → Major code
* **100** → Minor code
* **"My Exception"** → Description text

**PML Usage:**
```pml
!MyPMLNet.ThrowPMLNetException()
```

---

## 🧠 **More Explanation of Code Execution flow**

### **1. Import and Initialization**

* The `PMLNet_4` namespace is imported and linked.
* An instance of `MyPMLNet` is created:

  ```pml
  !MyPMLNet = object MyPMLNet()
  ```

### **2. Event Registration**

* The event handler is registered by linking a **PML object** and its **callback** method to the C# event:

  ```pml
  !handler = !MyPMLNet.addeventhandler('MyPmlNetEvent', !PmlObject, 'callback')
  ```

### **3. Triggering the Event**

* When `TriggerEvent()` is called in C#, it passes an array of arguments (`My Arg 1`, `My Arg 2`) back to the PML callback:

  ```pml
  !MyPMLNet.TriggerEvent()
  ```

* The callback displays the array contents:

  ```pml
  define method .callback(!array is array)
  q var !array
  endmethod
  ```

### **4. Exception Handling**

* `ThrowNormalException()` will throw a generic PML runtime error.
* `ThrowPMLNetException()` will show a structured error with detailed codes:

  ```
  Error Code: 1000-100
  Message: My Exception
  ```

---

## 🧩 **Debugging Tips**

* To debug the C# code, attach **Visual Studio** to the **E3D process (e3d.exe)**.
* Set breakpoints in your methods (`TriggerEvent`, `ThrowPMLNetException`, etc.).
* When executed from the PML Command Window, Visual Studio will halt at your breakpoints.

---
