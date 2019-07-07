XML

	 <Root>
	   <StringNode attribute ="AttributeValue">StringNodeValue</StringNode>
	   <ParentNode>
	     <IntNode>12345</IntNode>
	   </ParentNode>
	   <ListNode>
	     <Item>1</Item>
	     <Item>2</Item>
	     <Item>3</Item>
	     <Item>4</Item>
	   </ListNode>
	</Root>


Example

     XmlDocument xmlDoc = new XmlDocument();
     xmlDoc.Load("TestXml.xml");

     dynamic rootNode = xmlDoc.DocumentElement.ToDynamic();
     string stringValue = rootNode.StringNode;
     string attributeValue = rootNode.StringNode["attribute"];
     int intValue = rootNode.ParentNode.IntNode;
     int itemValue = rootNode.ListNode.Item[1];
     int xPathItemValue = rootNode("ListNode/Item")[2];
