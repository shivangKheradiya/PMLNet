# 🔹 PMLNet_3

Showcases method assignment and overriding in C# for use within PML scripts.

---

### 🧮 **Define Sample Variables in PML**

Before executing the examples, define the following PML variables:

```pml
!MyPMLNet = object MyPMLNet()
```

---

## ⚙️ **Examples and Use Cases**

### **1. `MyProperty`**

A **string property** exposed to PML for reading and writing values directly from within the AVEVA environment.

```csharp
[PMLNetCallable()]
public string MyProperty { get; set; }
```

**PML Usage:**

```pml
!myString = !MyPMLNet.MyProperty(|Shivang|)
q var !myString
q var !MyPMLNet.MyProperty()
```

---

### **2. Constructors**

The class defines two constructors:

* A **default constructor** that initializes the object.
* An **overloaded constructor** that accepts a string parameter for direct initialization of the `MyProperty` string value.

```csharp
[PMLNetCallable()]
public MyPMLNet() { }

[PMLNetCallable()]
public MyPMLNet(string myProperty)
{
    this.MyProperty = myProperty;
}
```

**PML Usage:**
```pml
!MyPMLNet       = object MyPMLNet()
q var !MyPMLNet.MyProperty()
!MyPMLNet		= object MyPMLNet(|Abcd Data|)
q var !MyPMLNet.MyProperty()
```

---

### **3. `Assign()` Method**

Used to **copy property values** from one `MyPMLNet` instance to another.
This is particularly useful when working with multiple PML object instances and only certain attributes or properties are required to copy during assigningment operation. in below example `MyProperty` is copied from current object to newly created object.

```csharp
[PMLNetCallable()]
public void Assign(MyPMLNet that)
{
    this.MyProperty = that.MyProperty;
}
```

**PML Usage:**
```pml
!NewMyPMLNet	= !MyPMLNet
q var !NewMyPMLNet.MyProperty()
```

---

### **4. `ToString()` Override**

Overrides the base `ToString()` method to return a custom identifier.
Although not PML callable, it helps in debugging or inspecting object instances.

```csharp
public override string ToString()
{
    return ("override MyPMLNet");
}
```

**PML Usage:**
```pml
!MyPMLNet.string()
```

---
