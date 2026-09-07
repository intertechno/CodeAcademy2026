import xml.etree.ElementTree as ET
import json

# XML data
xml_data = """
<library>
    <book>
        <title>Clean Code</title>
        <author>Robert C. Martin</author>
        <year>2008</year>
    </book>
    <book>
        <title>The Pragmatic Programmer</title>
        <author>Andrew Hunt</author>
        <year>1999</year>
    </book>
    <book>
        <title>Introduction to Algorithms</title>
        <author>Thomas H. Cormen</author>
        <year>2009</year>
    </book>
</library>
"""

# Parse XML
root = ET.fromstring(xml_data)

# Convert XML to dictionary
library = {"library": []}
for book in root.findall("book"):
    book_data = {}
    book_data["title"] = book.find("title").text
    
    # Collect all authors into a list
    authors = [author.text for author in book.findall("author")]
    book_data["author"] = authors if len(authors) > 1 else authors[0]
    
    book_data["year"] = book.find("year").text
    library["library"].append(book_data)

# Convert dictionary to JSON
json_data = json.dumps(library, indent=4)
print(json_data)
