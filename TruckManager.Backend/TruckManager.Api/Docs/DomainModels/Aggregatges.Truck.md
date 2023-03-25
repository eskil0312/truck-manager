# Domain models

## Truck

```csharp
class Truck()
{
    Truck CreateTruck();
    void RemoveTruck();
    void UpdateTruckSection(Section truckSections);
}
```

```json
{
    "id": "000-0000-0000",
    "userIds": [
        "0000-0000"
    ],
    "incidentIds": [
        "0000-0000"
    ],
    "companyId": "000-000",
    "brandModelId": "0000-0000",
    "registrationNumber": "string",
    "registrationDate": "Date",
    "veichleAllowenceExperationDate": "Date", // EU control

}
```