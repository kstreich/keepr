<template>
    <div class="container login">
        <div class="jumbotron mt-5">
            <h4 class="JTmargTop">Please login or register to start keeping new things.</h4>
            <form v-if="loginForm" @submit.prevent="loginUser">
                <input class="form-control" type="email" v-model="creds.email" placeholder="email">
                <input class="form-control" type="password" v-model="creds.password" placeholder="password">
                <button class="btn btn-sm btn-info mt-3" type="submit">Login</button>
            </form>
            <form v-else @submit.prevent="register">
                <input class="form-control" type="text" v-model="newUser.username" placeholder="name">
                <input class="form-control" type="email" v-model="newUser.email" placeholder="email">
                <input class="form-control" type="password" v-model="newUser.password" placeholder="password">
                <button class="btn btn-sm btn-info mt-3" type="submit">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm">
                <p class="JTmargBottom" v-if="loginForm">Don't have an account? Click here to Register.</p>
                <p class="JTmargBottom" v-else>Already have an account? Click here to Login.</p>
            </div>
        </div>
    </div>
</template>



<script>
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>

<style>
    .JTmargTop {
        margin-bottom: 4vh
    }

    .JTmargBottom {
        margin-top: 8vh
    }
</style>