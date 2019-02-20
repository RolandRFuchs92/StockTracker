# StockTracker Repository

### General rules

1. Make sure that all data that goes through here is pure. However we do not want to mix businesslogic with the repo.

2. Stuff like validation and decision structuring is the sole reposibility of the business logic.

3. EntityFramework will be the golden ORM as its easy to use and easily interchangable. This means that the repo patern is easy to change but if we have to do a major overhaul we can use something that isnt entity framework.

4. Ensure that there is <b><i>no tight coupling</i></b>


### Objective 

This assembly should be easily interchange able with another assembly that uses the same interfaces.

This assembly will be the primary point for data exchange.

### Purpose

  1. To make an interchange able service/repo layer.
  2. To Create a set of tools to shorten development time
  3. Reduce coupling
  4. Create a secure nest of logging, to enable for easy software monitoring
   

