using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SampleMessageForReference = "SampleMessageForReference";
        public static string ProjectCreated = "Project is created succesfully";
        public static string projectUpdated="Project is updated successfuly";
        public static string AuthorizationDenied = "You have not authorised for this operation";
        public static string AccessTokenCreated = "Access Token Created";
        public static string UserAlreadyExists = "User Already Exists";
        public static string SuccessfulLogin = "Successful Login";
        public static string PasswordError = "Password Error";
        public static string UserNotFound = "User not found";
        public static string UserRegistered = "User registered";
        public static string UserDetailAdded = "User detail added succesfully";
        public static string UserDetailDeleted = "User detail deleted succesfully";
        public static string UserDetailUpdated = "User detail updated succesfully";
        public static string UserAddedToProject = "User added to project succesfully ";
        public static string UserDeletedFromProject="User deleted from this project";
        public static string UserProjectUpdated = "UserProject updated succesfully";
        public static string ScoreAdded= " Score Table entry saved successfully.";
        public static string CustomerAdded= "New customer added successfully";
        public static string CustomerUpdated="Customer informations updated succesfully";
        public static string CustomerDeleted = "Customer Deleted successfully";
        public static string CustomerNotExist="Customer not exists";
        public static string CheckProjectAssigner="Project assigner is not exist in users!";
        public static string CheckProjectLead="Project leader is not exist in users!";
        public static string StartDateOfProjectError= "project for the past cannot be opened";
        public static string UserAllreadyExistInProject="user to be added  is already exist in this project";
        public static string ProjectNameExist="Project name is allready exists";
        public static string ProjectIsNotExists="Project is not exists";
    }
}
