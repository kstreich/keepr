import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    Allkeeps: [],
    UserVaults: [],
    CurrentVault: {},
    UserKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setAllKeeps(state, keeps) {
      state.Allkeeps = keeps
    },
    setUserVaults(state, vaults) {
      state.UserVaults = vaults
    },
    setCurrentVault(state, vault) {
      state.CurrentVault = vault
    },
    setUserKeeps(state, keeps) {
      state.UserKeeps = keeps
    }


  },
  actions: {

    //VAULTS
    getAllVaults({ commit, dispatch }) {
      api.get('/vaults')
        .then(res => {
          console.log("Vaults ->", res.data)
          commit('setUserVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(res => {
          commit('setUserVaults', res.data)
          dispatch('getAllVaults')
        })
    },
    getVaultById({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          console.log('CurrentVault ->', res.data)
          commit('setCurrentVault', res.data)
        })
    },

    //KEEPS
    getAllKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          console.log("Keeps ->", res.data)
          commit('setAllKeeps', res.data)
        })
    },
    createKeep({ commit, dispatch }, keep) {
      debugger
      api.post('/keeps', keep)
        .then(res => {
          console.log("Keep Created!")
          dispatch('getKeepsByUID')
        })
    },
    getKeepsByUID({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          console.log("User Keeps ->", res.data)
          commit('setUserKeeps', res.data)
        })
    },

    //VAULTKEEPS
    createVK({ commit, dispatch }, vkData) {
      api.post('vaultkeep', vkData)
        .then(res => {
          console.log('VK created!')
        })
    },

    //AUTH 
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          console.log("User ->", res.data)
          commit('setUser', res.data)
          // router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    }
  }
})