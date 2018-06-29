# SprinterraTestAssignment


1. Develop an event log library (the Logger)

    1.1 The logger should implement the following interface:
    ```c#
   public interface ILogger
    {
      void Info (string message);
      void Warn (string message);
      void Error (string message);
      void Debug (string message);
      void Fatal (string message);
   }
    ```
    1.2 Logger must support logging to various repositories, Repository change should be done without changing the class, implementing the ILogger interface;
    1.3 Logger must support simultaneous recording in multiple stores data (for example, console, text file, database, etc);
    1.4 Optional: The Logger must support message buffering and write the command buffer.
2. Develop ASP .NET Web Forms / ASP .NET MVC web application for solving the following task:
Landowners in the allocation of land are necessary determine the area of complex geometric shapes. Used such algorithm:
    ```
    1) determine the coordinates X, Y of the required number of k points, belonging to the boundary of the site;
    2) calculate the sum Σ(Y[i] * (X[i-1] - X[i+1])), where i ∈ [1,2,3 ... k];
    3) the plot area is determined as half the amount found;
    4) to control the obtained value, the required area is calculated with using the sum Σ(X[i] * (Y[i+1]-Y[i-1])), where i ∈ [1,2,3 ... k], which is divided in half;
    5) the obtained values are compared, and, if they are equal, the desired area is defined.
    ```
    Write a program that works in accordance with the specified algorithm and allows you to calculate the area of different land with different number of points.
    Functionality requirements:
    
    2.1 The application should make maximum use of the capabilities of the selected framework, with minimal use of third-party libraries. Of javascript / css libraries are allowed to use de-facto standard, such as jQuery, jQuery UI, Knockout, RequireJS, Bootstrap. For rendering / displaying coordinates and shapes - choosing a javascript library not limited. Use of IoC, design patterns and availability Module tests significantly increases the assessment for the task.
    
    2.2 In the application, DO NOT use the DB for storage / writing / reading data to implement the storage on the basis of a text / binary file.
    
    2.3 Integrate into the Logger application, implemented in step 1, for storage of logging data, use the step 2.1.
    
    2.4 Implement a page with an interface for a land calculator, with which the user can:
    - enter and edit coordinates;
    - see the result of the calculated area;
    - see a graphical display of the grid and land section in the form of a figure based on the entered coordinates.
    
    2.5 Implement the logging of user actions (opening a page, actions on coordinates (input, change, calculation results, results of validations, errors, warnings, etc);
    
    2.6 Implement a page to view the logging log (with possibility of filtering) in the form of a list with the possibility of switching the form for a detailed view.
    
3. The result is presented as a solution to Visual Studio 2017 (2015), packed in the archive (or send a link to the repository, located on GitHub / GitLab).
