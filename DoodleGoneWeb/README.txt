﻿DoodleGone
Web Application Security
2025-02-19

Eric Blachette:
11:17	having issues regarding git commits, saying access denied
11:46	still having issue, using adminstrator priveledges dont help
12:32	fixed issue, need to close visual studio entirely and commit with admin priviledges in powershell
1:20	made all branches for development, and structed in heirarchy underneath main
1:53	made initial view controller and fixed server side error bug
3:43	created eraser object
3:50	created mock eraser data
4:30	created the page to display eraser objects

Bhumi Patel: 
2025-02-19
10:30 - Started working on the "About Us" page feature.
10:34 - Updated HomeController.cs to include an About() method.
10:42 - Created a new About.cshtml view inside Views/Home/.
10:45 - Added HTML structure and team details to About.cshtml.
10:56 - Updated _Layout.cshtml to include a navigation link to About Us.
11:02 - Tested the "About Us" page locally to ensure proper functionality.
11:05 - having issues regarding git commits, saying access denied (Eric had the same issues so he guided me)
02:30 - fixed issue as he expained to me, i need to close visual studio entirely and commit with admin priviledges in powershell
02:35 - created all the braches again 
02:48 - tried to test it, worked sucessfully.


﻿DoodleGone
Web Application Security
Bhumi Patel
2025-03-07
10:15 - Started implementing Role-Based Access Control (RBAC) in Program.cs.
10:20 -  admin credentials:
================================
 ID : eric@doodlegone.ca
 Password : Admin@1234
================================
10:25 -  guest user credentials:
==================================
 user1 ID - bhumi@doodlegone.ca
 user1 Password - User@0709

 user2 ID = vikas@doodlegone.ca
 user2 Password = Vika@4554
===============================
10:30 - Updated Program.cs to implement Role-Based Access Control (RBAC) for Admin and Guest roles.
10:38 - Configured user roles inside the authentication logic.
10:45 - Implemented middleware to enforce role-based access for different parts of the system.
10:55 - Tested authentication and access control for Admin and Guest users.
11:05 - Verified login functionalities and restricted access based on user roles.
11:15 - Debugged minor issues related to role assignment and authentication logic.
11:30 - Finalized and committed changes.