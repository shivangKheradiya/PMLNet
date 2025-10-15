# 🔹 PMLNet_5

This guide demonstrates how to create and interact with **PML objects** directly from **C#** using **PMLNet** integration within **AVEVA E3D**.
The example shows how to call **PML object methods**, **exchange data**  between the **C# environment** and **PML scripts** dynamically.

---

## 🛠️ **Overview**

The `PMLNet_5` example focuses on:

* Creating and controlling **PML objects** from C#.
* Invoking **PML methods** dynamically using `PMLNetAny.invokeMethod`.
* Exchanging **arrays and PmlAny** between C# and PML objects.

This demonstrates advanced interoperability between **PML** and **C#**, enabling developers to build tightly coupled and data-synchronized modules.

---

## 💻 **C# Implementation Explanation for Components**

### **1. PML Object Creation**

Creates an instance of a **PML object** within the C# runtime environment:

```csharp
var PmlObject = PMLNetAny.createInstance("PMLOBJECT", new object[] { }, 0, true);
```

This enables C# to instantiate and communicate with native PML-defined objects.

---

### **2. Calling PML Methods from C#**

#### **a. Calling `getArray()`**

The C# code calls the PML method `getArray` and retrieves an array result into a `Hashtable`:

```csharp
object pmlArrayObject = new Hashtable();
PmlObject.invokeMethod("getArray", new object[] { "myArrayPrinting" }, 1, ref pmlArrayObject, true, true);
```

This retrieves data from PML and makes it available as a **Hashtable** in C#.

#### **b. Calling `setArray()`**

Similarly, a new hashtable is created and passed back to PML:

```csharp
var scopeElements = new Hashtable();
scopeElements.Add(1, "/TEST-ISO-OPS");

object pmlNullObject = new object();
PmlObject.invokeMethod("setArray", new object[] { scopeElements }, 1, ref pmlNullObject, true, true);
```

This method pushes structured data back into PML for further use or validation. In our example check the commandline for seeing the transfered `array`.

---

## 🧠 **More Explanation of Code Execution flow**

1. The DLL `PMLNet_5.dll` is imported and linked.
2. An instance of the class `MyPMLNet` is created.
3. The method `TestHashTableFromObject()` is executed:

   * Creates a PML object (`PmlObject`).
   * Calls `.getArray()` to retrieve data from PML into C#.
   * Calls `.setArray()` to send data back from C# to PML.

---

## ✅ **Summary**

The `PMLNet_5` project demonstrates:

* Creating and invoking **PML objects directly from C#**.
* Exchanging **data** dynamically between **PML and .NET**.
* Practical usage of **`PMLNetAny`** for deep integration between C# logic and PML data structures.

This is an essential step toward building **intelligent, bi-directional communication layers** within the **AVEVA E3D customization framework**.
