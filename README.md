# Test Data Generator

## How To Use 

1) Use your preferred text editor to make a .json file called test_generator_config.json


2) Copy the following JSON into test_generator_config.json

```
{
	"header_table": {
		"columns": [],
		"rows": []
	},

	"data_table": {
		"columns": [],
		"rows": []
	},

	"trailer_table": {
		"columns": [],
		"rows": []
	}
}
```

3) In the `columns` field add in the names you would like each field in your record to have. Example below:

```
{
	"header_table": {
		"columns": ["File Type", "Origin Server", "Receiving Server"],
		"rows": []
	},

	"data_table": {
		"columns": ["First Name", "Last Names", "DOB", "Company Name"],
		"rows": []
	},

	"trailer_table": {
		"columns": ["File Type", "Record Quantity"],
		"rows": []
	}
}
```

Note: Do not put anything in the `rows` field.

4) Ensure the test_generator_config.json is in the same directory as the TestDataGeneratorApp.exe.


5) Open the .exe and follow the in-app instructions to generate your data.



This application uses the [Bogus library](https://github.com/bchavez/Bogus) to generate data.
