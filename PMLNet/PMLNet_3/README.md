# 🔹 PMLNet_3

Showcases method assignment and overriding in C# for use within PML scripts.

---

## ⚙️ **Explanation of Components**

### **2. `MyProperty`**

A **string property** exposed to PML for reading and writing values directly from within the AVEVA environment.

```csharp
[PMLNetCallable()]
public string MyProperty { get; set; }
```

---

### **3. Constructors**

The class defines two constructors:

* A **default constructor** that initializes the object.
* An **overloaded constructor** that accepts a string parameter for direct initialization of the `MyProperty` value.

```csharp
[PMLNetCallable()]
public MyPMLNet() { }

[PMLNetCallable()]
public MyPMLNet(string myProperty)
{
    this.MyProperty = myProperty;
}
```

---

### **4. `Assign()` Method**

Used to **copy property values** from one `MyPMLNet` instance to another.
This is particularly useful when working with multiple PML object instances.

```csharp
[PMLNetCallable()]
public void Assign(MyPMLNet that)
{
    this.MyProperty = that.MyProperty;
}
```

---

### **5. `ToString()` Override**

Overrides the base `ToString()` method to return a custom identifier.
Although not PML callable, it helps in debugging or inspecting object instances.

```csharp
public override string ToString()
{
    return ("override MyPMLNet");
}
```

---

## 💻 **PML Usage Examples**

### **1. Creating and Using Default Constructor**

```pml
!MyPMLNet_1 = object MyPMLNet()
!MyPMLNet_1.MyProperty(|Hello from AVEVA|)
q var !MyPMLNet_1.MyProperty()
```
---

### **2. Using Overloaded Constructor**

Initialize the property value directly during object creation.

```pml
!MyPMLNet_2 = object MyPMLNet(|Overloaded Constructor|)
q var !MyPMLNet_2.MyProperty()
```
---

### **3. Assigning One Object to Another**

Copy property values from one PMLNet object to another using the `Assign()` method.

```pml
!MyPMLNet_1 = object MyPMLNet(|Source Value|)
!MyPMLNet_2 = object MyPMLNet()
!MyPMLNet_2.Assign(!MyPMLNet_1)
q var !MyPMLNet_2.MyProperty()
```
---

### **4. Verifying ToString() Override**

Although not PML callable directly, you can verify the overridden `ToString()` output during debugging or by inspecting the object from C#.

```csharp
Console.WriteLine(new MyPMLNet().ToString());
// Output: override MyPMLNet
```

---
