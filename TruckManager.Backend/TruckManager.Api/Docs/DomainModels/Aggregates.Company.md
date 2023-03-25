# Domain models

## Company

```csharp
class Company()
{
    Company CreateCompany();
    void RemoveCompany();
    void UpdateCompanySection(Section companySections);
}
```

```json
{
    "id": "000-0000-0000",
    "userIds": [
        "0000-0000"
    ],

}
```