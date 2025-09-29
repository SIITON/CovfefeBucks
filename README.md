Add order

```
{
  "customer": "Simon",
  "coffeeDetails": [
    {
      "type": "espresso",
      "size": "medium"
    }
  ]
}
```

Get orders:

```
[
    {
      "id": "73f2258b-9601-42fa-9bd7-98d643d26053",
      "customer": "Simon",
      "coffee": [
        {
          "name": "Espresso",
          "beanType": "Arabica",
          "price": 2.5,
          "size": "Medium",
          "hasMilk": false,
          "milkType": "None"
        }
      ]
    }
  ]
```
