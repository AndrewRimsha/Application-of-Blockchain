# Application-of-Blockchain
A visual application of blockchain technology with such protection mechanisms as authentication, verification of the user's balance, signature, transaction date, calculation of nonce and hash are demonstrated. The developed application implements the storage of records with money transactions between users.
<br><br>
![Authentication Form](https://github.com/AndrewRimsha/Application-of-Blockchain/blob/main/screenshots/01_Authentication.png "Authentication Form")
1. TextBox with path to xml-file with private key;
2. Button “Find Path” to open file dialog with file search;
3. Button “Log in” for user authentication from xml-file;
4. Button “Exit” for close the program.

<br><br>
![Main Form](https://github.com/AndrewRimsha/Application-of-Blockchain/blob/main/screenshots/02_Main_Form.png "Main Form")
1. TextBox with path to blockchain-file;
2. Button “Find Path” to open file dialog with file search;
3. Button “Read” to read blockchain file;
4. Label with id of user;
5. Label with balance of current user;
6. Button “Log out” to log out and return to Authentication form;
7. Label with name of current user;
8. Label with status of reading blockchain file;
9. Label with date of last action with blockchain file;
10. Checkbox “Autosave” to save automatically after any action;
11. Button “Save” to save changes to blockchain file;
12. DataGridView with blocks of blockchain;
13. Button “Check Balance” to check the balance of all users and search for blocks with violation;
14. Button “Check Date” to check the date to find duplicates;
15. Button “Check Hash” to check the hash of previous blocks to find violations;
16. Button “Check Signature” to check the signature by public key of each user for blocks;
17. Button “Check Nonce” to check the nonce of all blocks;
18. Button “Validate Blockchain” to check balance, date, hash, signature, nonce for all blocks;
19. Label with status of validating blockchain;
20. DataGridView with requests of current user;
21. Button “Send Money” to send money to other user;
22. Button “Create Request” to create request for user;
23. Button “Remove Unvalidated Blocks” to remove only blocks with violations;
24. Button “Remove Unvalidated Chain” to remove all blocks after first block with violation.

<br><br>
![Send Money Form](https://github.com/AndrewRimsha/Application-of-Blockchain/blob/main/screenshots/03_Send_Money_Form.png "Send Money Form")
1. TextBox with sender address (public key);
2. ComboBox with recipient address (public key);
3. NumericUpDown with amount of the transaction;
4. Button “Send” to complete the transaction;
5. Button “Cancel” to close SendMoney form.

<br><br>
![Request Form](https://github.com/AndrewRimsha/Application-of-Blockchain/blob/main/screenshots/04_Request_Form.png "Request Form")
1. TextBox with address of creator (current user);
2. TextBox with information about request;
3. ComboBox with recipient address;
4. NumericUpDown with total amount;
5. NumericUpDown with number of senders;
6. Button “Separate” to divide total amount among all senders;
7. TextBox with address of first sender;
8. NumericUpDown with amount from first sender;
9. TextBox with address of second sender;
10. NumericUpDown with amount from second sender;
11. TextBox with address of third sender;
12. NumericUpDown with amount from third sender;
13. TextBox with address of forth sender;
14. NumericUpDown with amount from forth sender;
15. TextBox with address of fifth sender;
16. NumericUpDown with amount from fifth sender;
17. TextBox with address of sixth sender;
18. NumericUpDown with amount from sixth sender.
